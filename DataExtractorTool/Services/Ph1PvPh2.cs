using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataExtractorTool.Services
{
    public class Ph1PvPh2 : CalculateBase
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
            var fenmu = inputData.S1 - inputData.S2 * dr;

            int coefficient;
            double xStart;
            if (fenmu > 0)
            {
                coefficient = -1;
                xStart = 2 * dr / (dr + 1);
            }
            else
            {
                coefficient = 1;
                xStart = (dr + 1) / (2 * dr);
            }
            var item = coefficient * config.ErleiIncreaseNumber;

            return Parallel.For(1, config.ErleiLoopCount, (i, state) =>
            {
                var x = item * i + xStart;
                var t = (dr * randP * (2 - x) - randP * x) / fenmu;

                if (t < config.TMinimumValue) return;

                var ph1 = s1 * t + randP * x;
                var pv = s3 * t + randP;
                var ph2 = s2 * t + randP * (2 - x);

                var flag1 = ph1 > pv + config.DefaultDeviation && pv > ph2 + config.DefaultDeviation;
                var flag2 = Math.Abs(ph1 / ph2 - dr) <= FloatDeviation;

                if (!flag2 || !flag1) return;

                inputData.X = x;
                inputData.T = t;
                inputData.Ph1 = ph1;
                inputData.Ph2 = ph2;
                inputData.Pv = pv;

                stopwatch.Stop();
                //Debug.WriteLine($"执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP:F4},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},fenmu={fenmu}");
                state.Stop();
            });
        }

        private static int ExtractCoefficient(double dr, double randP, double s1, double s2, double s3, double fenmu)
        {
            var leftX = 2 * dr / (1 + dr) - 1;
            var leftT = (dr * randP * (2 - leftX) - randP * leftX) / fenmu;
            var leftPh1 = s1 * leftT + randP * leftX;
            var leftPv = s3 * leftT + randP;
            var left = leftPh1 - leftPv;


            var rightX = 2 * dr / (1 + dr) + 1;
            var rightT = (dr * randP * (2 - rightX) - randP * rightX) / fenmu;
            var rightPh1 = s1 * rightT + randP * rightX;
            var rightPv = s3 * rightT + randP;
            var right = rightPh1 - rightPv;

            var coefficient = 1;
            if (left > right)
            {
                coefficient = -1; //动态的判断当前的x应该是递增还是递减
            }

            return coefficient;
        }

        public void FindOne(InputData inputData)
        {
            var config = new CalculateConfig()
            {
                ErleiLoopCount = 20000000,
                RandomNumberType = RandomNumberType.RandomNumberPerRecord,
                ErleiIncreaseNumber = 0.00001d
            };
            var s1 = inputData.S1;
            var s2 = inputData.S2;
            var s3 = inputData.S3;

            //按配置来确定
            var randP = inputData.RandP;

            var dr = inputData.Dr;
            var fenmu = inputData.S1 - inputData.S2 * dr;

            var i = 1;
            var basenumber = 2 * dr / (1 + dr);
            while (true)
            {
                var x = basenumber + config.ErleiIncreaseNumber * i++;
                var t = (dr * randP * (2 - x) - randP * x) / fenmu;
                var ph1 = s1 * t + randP * x;
                var pv = s3 * t + randP;
                var ph2 = s2 * t + randP * (2 - x);

                Debug.WriteLine($"S1={s1},s2={s2},s3={s3},x={x},t={t},ph1={ph1:F4},pv={pv:F4},ph2={ph2:F4},ph1/ph2={ph1 / ph2:F4}");

                var flag1 = ph1 > pv + config.DefaultDeviation && pv > ph2 + config.DefaultDeviation;
                var flag2 = Math.Abs(ph1 / ph2 - dr) <= FloatDeviation;

                if (!flag2 || !flag1) continue;

                inputData.X = x;
                inputData.T = t;
                inputData.Ph1 = ph1;
                inputData.Ph2 = ph2;
                inputData.Pv = pv;

                // Debug.WriteLine($"符合条件：S1={s1},S2={s2},S3={s3},RandP={randP:F4},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");

                break;
            }

        }
    }
}