using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DataExtractor
{
    class Program
    {
        private const double IncreaseNumber = 0.00001d;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            ParallelRun();

            stopwatch.Stop();

            FileReader.SaveBaseData(RecordStack.ToList());

            Console.WriteLine($"完成{RecordStack.Count}.总耗时{stopwatch.Elapsed.TotalSeconds}s");

            Console.ReadLine();
        }

        /// <summary>
        /// 可以得到结果，但是计算较慢
        /// </summary>
        static void ParallelRun()
        {
            var data = FileReader.ReadBaseData();
            int index = 1;

            Parallel.ForEach(data, inputData =>
            {
                var s1 = inputData.S1;
                var s2 = inputData.S2;
                var s3 = inputData.S3;
                var randP = inputData.RandP;
                var dr = inputData.Dr;
                var fenmu = inputData.S3 * dr - inputData.S1;
                var item = fenmu > 0 ? -1 * IncreaseNumber : IncreaseNumber;
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

                    if (flag2 && flag1 && !RecordStack.Contains(inputData))
                    {
                        inputData.X = x;
                        inputData.T = t;
                        inputData.Ph1 = ph1;
                        inputData.Ph2 = ph2;
                        inputData.Pv = pv;

                        stopwatch.Stop();
                        RecordStack.Push(inputData);
                        Debug.WriteLine($"成功:{index++},执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");
                        state.Stop();
                    }
                });

                //var x = 1 / inputData.Dr;
                //int count = 0;
                //while (true)
                //{
                //    count++;
                //    if (IsValidX(x, inputData))
                //    {
                //        inputData.Count = count;
                //        stopwatch.Stop();
                //        RecordStack.Push(inputData);
                //        Debug.WriteLine($"成功:{index++},当前遍历次数:{count},执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={inputData.S1},S2={inputData.S2},S3={inputData.S3},RandP={inputData.RandP},Dr={inputData.Dr},X={inputData.X},T={inputData.T},Ph1={inputData.Ph1},Ph2={inputData.Ph2},Pv={inputData.Pv},S3*Dr-S1={inputData.S3 * inputData.Dr - inputData.S1}");
                //        break;
                //    }
                //    x += item;
                //}
            });
        }

        static bool IsValidX(double x, double t, double ph1, double ph2, double pv, double dr)
        {
            var flag1 = ph1 > ph2 && ph2 > pv;
            var flag2 = Math.Abs(ph1 / pv - dr) <= 0.0001;
            return flag2 && flag1;
        }

        private static readonly ConcurrentStack<InputData> RecordStack = new ConcurrentStack<InputData>();
        private static readonly ConcurrentStack<InputData> FailedRecordStack = new ConcurrentStack<InputData>();

        static void ParallelRun2()
        {
            var data = FileReader.ReadBaseData();
            int index = 1;

            Parallel.ForEach(data, inputData =>
            {
                var s1 = inputData.S1;
                var s2 = inputData.S2;
                var s3 = inputData.S3;
                var randP = inputData.RandP;
                var dr = inputData.Dr;
                var fenmu = inputData.S3 * dr - inputData.S1;
                var item = fenmu > 0 ? -1 * IncreaseNumber : IncreaseNumber;
                Stopwatch stopwatch = Stopwatch.StartNew();

                var i = 0;

                while (true)
                {
                    var x = item * i + 1 / dr;
                    var t = randP * (1 - x * dr) / fenmu;
                    var ph1 = s1 * t + randP;
                    var ph2 = s2 * t + randP * (2 - x);
                    var pv = s3 * t + randP * x;

                    var flag1 = ph1 > ph2 && ph2 > pv;
                    var flag2 = Math.Abs(ph1 / pv - dr) <= 0.0001;

                    if (flag2 && flag1)
                    {
                        stopwatch.Stop();
                        RecordStack.Push(inputData);
                        Debug.WriteLine($"成功:{index++},执行完一条耗时:{stopwatch.ElapsedMilliseconds}ms。符合条件：S1={s1},S2={s2},S3={s3},RandP={randP},Dr={dr},X={x},T={t},Ph1={ph1},Ph2={ph2},Pv={pv},S3*Dr-S1={fenmu}");
                    }
                }
            });
        }

    }
}
