using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataExtractor.Services;

namespace DataExtractor
{
    class Program
    {
        private static readonly ConcurrentBag<InputData> RecordStack = new ConcurrentBag<InputData>();

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var defaultFile = Path.Combine(baseDirectory, "testdata.dat");

            var dataList = FileReader.ReadBaseData(defaultFile);

            var result = Parallel.ForEach(dataList, inputData =>
            {
                var service = new Ph1Ph2Pv();
                service.ParallelRun(new CalculateConfig(), inputData);
                if (!RecordStack.Contains(inputData)) { RecordStack.Add(inputData); }

                Console.WriteLine($"已处理完成{RecordStack.Count(c => c.T > 0 || c.T < 0)}条记录");
            });


            if (result.IsCompleted)
            {
                Console.WriteLine("全部数据遍历完成...");
            }

            var savedFile = Path.Combine(baseDirectory, "result.dat");
            FileReader.SaveBaseData(savedFile, dataList);

            stopwatch.Stop();
            Console.WriteLine($"完成.总耗时{stopwatch.Elapsed.TotalSeconds}s");
            Console.ReadLine();
        }
    }
}
