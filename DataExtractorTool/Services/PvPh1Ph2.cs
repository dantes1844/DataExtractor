using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataExtractorTool.Services
{
    public class PvPh1Ph2 : CalculateBase
    {
        public override ParallelLoopResult ParallelRun(CalculateConfig config, InputData inputData)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var s1 = inputData.S1;
            var s2 = inputData.S2;
            var s3 = inputData.S3;

            //按配置来确定
            var randP = inputData.RandP;

            var dr = inputData.Dr;
            var fenmu = inputData.S3 - inputData.S2 * dr;

            var coefficient = ExtractCoefficient(dr, randP, s1, s2, s3, fenmu);
            var item = coefficient * config.SanleiIncreaseNumber;

            return Parallel.For(0, config.SanleiLoopCount, (i, state) =>
            {
                var x = item * i + dr;
                var t = randP * (dr - x) / fenmu;
                var pv = s3 * t + randP * x;
                var ph1 = s1 * t + randP * (2 - x);
                var ph2 = s2 * t + randP;

                var flag1 = pv > ph1 + config.DefaultDeviation && ph1 > ph2 + config.DefaultDeviation;
                var flag2 = Math.Abs(pv / ph2 - dr) <= 0.0001;

                if (!flag2 || !flag1) return;

                inputData.X = x;
                inputData.T = t;
                inputData.Ph1 = ph1;
                inputData.Ph2 = ph2;
                inputData.Pv = pv;

                stopwatch.Stop();
                Debug.WriteLine($"执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP:F4},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");
                state.Stop();
            });
        }

        private static int ExtractCoefficient(double dr, double randP, double s1, double s2, double s3, double fenmu)
        {
            var leftX = dr - 1;
            var leftT = randP * (dr - leftX) / fenmu;
            var leftPv = s3 * leftT + randP * leftX;
            var leftPh1 = s1 * leftT + randP * (2 - leftX);
            var left = leftPv - leftPh1;

            var rightX = dr + 1;
            var rightT = randP * (dr - rightX) / fenmu;
            var rightPv = s3 * rightT + randP * rightX;
            var rightPh1 = s1 * rightT + randP * (2 - rightX);
            var right = rightPv - rightPh1;

            var coefficient = 1;
            if (left < right)
            {
                coefficient = -1; //动态的判断当前的x应该是递增还是递减
            }

            return coefficient;
        }

        public void FindOne(InputData inputData)
        {
            var config = new CalculateConfig()
            {
                DefaultDeviation = 2,
                SanleiLoopCount = 20000,
                SanleiIncreaseNumber = 0.1
            };
            var fenmu = inputData.S3 - inputData.S2 * inputData.Dr;
            var coefficient = ExtractCoefficient(inputData.Dr, inputData.RandP, inputData.S1, inputData.S2, inputData.S3, fenmu);

            var item = coefficient * config.SanleiIncreaseNumber;
            var x = inputData.Dr;
            var i = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            do
            {
                x += item;
                var t = inputData.RandP * (inputData.Dr - x) / fenmu;
                var pv = inputData.S3 * t + inputData.RandP * x;
                var ph1 = inputData.S1 * t + inputData.RandP * (2 - x);
                var ph2 = inputData.S2 * t + inputData.RandP;

                var flag1 = pv > ph1 + config.DefaultDeviation && ph1 > ph2 + config.DefaultDeviation;
                var flag2 = Math.Abs(pv / ph2 - inputData.Dr) <= 0.0001;


                Debug.WriteLine($"S1={inputData.S1},S2={inputData.S2},S3={inputData.S3},RandP={inputData.RandP:F4},Dr={inputData.Dr},X={x},T={t},Pv={pv},Ph1={ph1},Ph2={ph2},pv-ph1={pv - ph1},fenmu={fenmu}");


                if (!flag2 || !flag1)
                {
                    i++;
                    continue;
                }

                inputData.X = x;
                inputData.T = t;
                inputData.Ph1 = ph1;
                inputData.Ph2 = ph2;
                inputData.Pv = pv;

                stopwatch.Stop();
                Debug.WriteLine($"执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={inputData.S1},S2={inputData.S2},S3={inputData.S3},RandP={inputData.RandP:F4},Dr={inputData.Dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");

                break;
            } while (i <= config.SanleiLoopCount);

        }
    }
}