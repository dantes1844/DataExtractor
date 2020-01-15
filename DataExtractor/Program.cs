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
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var defaultFile = Path.Combine(baseDirectory, "testdata.dat");

            var dataList = FileReader.ReadBaseData(defaultFile);
            CaculateService.ParallelRun(dataList);

            var savedFile = Path.Combine(baseDirectory, "result.dat");
            FileReader.SaveBaseData(savedFile, dataList);

            stopwatch.Stop();
            Console.WriteLine($"完成.总耗时{stopwatch.Elapsed.TotalSeconds}s");
            Console.ReadLine();
        }
    }
}
