using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Services
{
    public class CaculateService
    {
        private const double IncreaseNumber = 0.00001d;
        private static readonly ConcurrentStack<InputData> RecordStack = new ConcurrentStack<InputData>();

        public static void ParallelRun(List<InputData> data)
        {
            int index = 1;

            Parallel.ForEach(data, inputData =>
            {
                var s1 = inputData.S1;
                var s2 = inputData.S2;
                var s3 = inputData.S3;
                var randP = inputData.RandP;
                var dr = inputData.Dr;
                var fenmu = inputData.S3 * dr - inputData.S1;

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
                var item = coefficient * IncreaseNumber;
                Stopwatch stopwatch = Stopwatch.StartNew();

                var loopStart = 0;
                var loopEnd = 20000000;

                Parallel.For(loopStart, loopEnd, (i, state) =>
                {
                    var x = item * i + 1 / dr;
                    var t = randP * (1 - x * dr) / fenmu;
                    var ph1 = s1 * t + randP;
                    var ph2 = s2 * t + randP * (2 - x);
                    var pv = s3 * t + randP * x;

                    var flag1 = ph1 > ph2 + 2 && ph2 > pv + 2;
                    var flag2 = Math.Abs(ph1 / pv - dr) <= 0.0001;

                    if (!flag2 || !flag1) return;

                    if (RecordStack.Contains(inputData)) return;

                    inputData.X = x;
                    inputData.T = t;
                    inputData.Ph1 = ph1;
                    inputData.Ph2 = ph2;
                    inputData.Pv = pv;

                    stopwatch.Stop();
                    RecordStack.Push(inputData);
                    Debug.WriteLine($"成功:{index++},执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP:F4},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");
                    state.Stop();
                });
            });
        }

        /// <summary>
        /// 为了查找特殊数字的，结果证明t不一定是大于0的
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
            var item = IncreaseNumber;
            Stopwatch stopwatch = Stopwatch.StartNew();

            var x = -714.698 + item;
            while (true)
            {
                var t = randP * (1 - x * dr) / fenmu;
                var ph1 = s1 * t + randP;
                var ph2 = s2 * t + randP * (2 - x);
                var pv = s3 * t + randP * x;

                var flag1 = ph1 > ph2 + 2 && ph2 > pv + 2;
                var flag2 = Math.Abs(ph1 / pv - dr) <= 0.0001;

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
