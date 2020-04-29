using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EssentialCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var directory = @"D:\codes\fortran\covid\aratedata";
            EncryptFiles(directory,"*");


            Console.WriteLine("全部加密完成...");
        }

        static void EncryptFiles(string directoryPath, string searchPattern)
        {
            string stars = "*".PadRight(Console.WindowWidth - 1, '*');
            var files = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);

            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions parallelOptions = new ParallelOptions()
            {
                CancellationToken = cts.Token
            };
            cts.Token.Register(() =>
            {
                Console.WriteLine("Cancelling...");

            });

            Console.WriteLine("Push enter to exit");

            Task task = Task.Run(() =>
            {

                try
                {
                    Parallel.ForEach(files, parallelOptions, (filename, loopstates) =>
                    {
                        EncryptFile(filename);
                    });
                }
                catch (OperationCanceledException e)
                {
                }

            });
            Console.Read();
            cts.Cancel();

            Console.WriteLine(stars);

            task.Wait();

            

        }

        static void EncryptFile(string filename)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"{filename}加密完成...");
        }
    }
}
