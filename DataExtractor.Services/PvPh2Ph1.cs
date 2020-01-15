using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Services
{
    public class PvPh2Ph1 : CalculateBase
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

            var coefficient = ExtractCoefficient(dr, randP, s1, s2, s3, fenmu);
            var item = coefficient * IncreaseNumber;

            return Parallel.For(0, LoopCount, (i, state) =>
             {
                 var x = item * i + 1 / dr;
                 var t = randP * (1 - x * dr) / fenmu;
                 var ph1 = s1 * t + randP;
                 var ph2 = s2 * t + randP * (2 - x);
                 var pv = s3 * t + randP * x;

                 var flag1 = ph1 > ph2 + config.DefaultDeviation && ph2 > pv + config.DefaultDeviation;
                 var flag2 = Math.Abs(ph1 / pv - dr) <= 0.0001;

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

        private static int ExtractCoefficient(double dr, double randP, double s1, double s2, double s3, double fenmu)
        {
            var leftX = 1 / dr - 1;
            var leftT = randP * (1 - leftX * dr) / fenmu;
            var leftPh1 = s1 * leftT + randP;
            var leftPh2 = s2 * leftT + randP * (2 - leftX);
            var left = leftPh1 - leftPh2;

            var rightX = 1 / dr + 1;
            var rightT = randP * (1 - rightX * dr) / fenmu;
            var rightPh1 = s1 * rightT + randP;
            var rightPh2 = s2 * rightT + randP * (2 - rightX);
            var right = rightPh1 - rightPh2;

            var coefficient = 1;
            if (left > right)
            {
                coefficient = -1; //动态的判断当前的x应该是递增还是递减
            }

            return coefficient;
        }
    }
}
