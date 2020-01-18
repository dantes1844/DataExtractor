using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataExtractorTool.Models;

namespace DataExtractorTool.Services
{
    public class Ph1Ph2Pv : CalculateBase
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
            var fenmu = inputData.S3 * dr - inputData.S1;

            int coefficient;
            if (fenmu > 0)
            {
                coefficient = -1;
            }
            else
            {
                coefficient = 1;
            }
            var item = coefficient * config.YileiIncreaseNumber;
            var start = config.TypeOneDefaultX ?? 1 / dr;

            return Parallel.For(0, config.YileiLoopCount, (i, state) =>
            {
                var x = item * i + start;
                var t = randP * (1 - x * dr) / fenmu;

                if (t < config.TMinimumValue) return;

                var ph1 = Ph1(s1, t, randP);
                var ph2 = Ph2(s2, t, randP, x);
                var pv = Pv(s3, t, randP, x);

                var flag1 = ph1 > ph2 + config.DefaultDeviation && ph2 > pv + config.DefaultDeviation;
                var flag2 = Math.Abs(ph1 / pv - dr) <= FloatDeviation;

                if (!flag2 || !flag1) return;

                inputData.X = x;
                inputData.T = t;
                inputData.Ph1 = ph1;
                inputData.Ph2 = ph2;
                inputData.Pv = pv;

                stopwatch.Stop();
                //Debug.WriteLine($"执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP:F4},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");
                state.Stop();
            });
        }

        private static double T(double randP, double x, double dr, double fenmu)
        {
            return randP * (1 - x * dr) / fenmu;
        }

        private static double Ph1(double s1, double t, double randP)
        {
            return s1 * t + randP;
        }

        private static double Ph2(double s2, double t, double randP, double x)
        {
            return s2 * t + randP * (2 - x);
        }

        private static double Pv(double s3, double t, double randP, double x)
        {
            return s3 * t + randP * x;
        }

        private static int ExtractCoefficient(double dr, double randP, double s1, double s2, double s3, double fenmu)
        {
            var leftX = 1 / dr - 1;
            var leftT = T(randP, leftX, dr, fenmu);
            var leftPh1 = Ph1(s1, leftT, randP);
            var leftPh2 = Ph2(s2, leftT, randP, leftX);
            var left = leftPh1 - leftPh2;

            var rightX = 1 / dr + 1;
            var rightT = T(randP, rightX, dr, fenmu);
            var rightPh1 = Ph1(s1, rightT, randP);
            var rightPh2 = Ph2(s2, rightT, randP, rightX);
            var right = rightPh1 - rightPh2;

            var coefficient = 1;
            if (left > right)
            {
                coefficient = -1; //动态的判断当前的x应该是递增还是递减
            }

            return coefficient;
        }

        /// <summary>
        ///     为了查找特殊数字的，结果证明t不一定是大于0的
        /// </summary>
        public static void FindOne()
        {
            int index = 1;

            var s1 = 0.131;
            var s2 = -169;
            var s3 = 169;
            var randP = 165.03;
            var dr = 3.3955;
            var fenmu = s3 * dr - s1;
            var item = 0.00001d;
            Stopwatch stopwatch = Stopwatch.StartNew();

            var x = -714.698 + item;
            while (true)
            {
                var t = T(randP, x, dr, fenmu);
                var ph1 = Ph1(s1, t, randP);
                var ph2 = Ph2(s2, t, randP, x);
                var pv = Pv(s3, t, randP, x);

                var flag1 = ph1 > ph2 + 2 && ph2 > pv + 2;
                var flag2 = Math.Abs(ph1 / pv - dr) <= FloatDeviation;

                if (flag2 && flag1)
                {
                    stopwatch.Stop();
                    Debug.WriteLine($"成功:{index++},执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1:F4},S2={s2:F4},S3={s3:F4},RandP={randP:F4},Dr={dr:F4},X={x:F4},T={t:F4},Ph1={ph1:F4},Ph2={ph2:F4},Pv={pv:F4},S3*Dr-S1={fenmu:F4}");
                    break;
                }

                Debug.WriteLine($"{index++},X={x:F4},T={t:F4},Ph1={ph1:F4},Ph2={ph2:F4},Pv={pv:F4},Ph1-Ph2={ph1 - ph2:F4}");
                x += item;
            }
        }
    }
}