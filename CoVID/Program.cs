using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoVID
{
    class Program
    {
        private const string CodeDirectory = @"D:\codes\fortran\covid";
        static void Main(string[] args)
        {
            var files = GenerateFiles();
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, files.Count, c =>
            {
                Console.WriteLine($"i={c}开始...");
                var startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = CodeDirectory;
                startInfo.FileName = "cmd.exe";
                startInfo.UseShellExecute = false; //关闭Shell的使用  
                startInfo.RedirectStandardInput = true; //重定向标准输入  
                startInfo.RedirectStandardOutput = true; //重定向标准输出  
                startInfo.RedirectStandardError = true; //重定向错误输出  
                startInfo.CreateNoWindow = true; // 设置不显示窗口  
                startInfo.ErrorDialog = false;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                var cmd = Process.Start(startInfo);
                var file = files[c];
                cmd.StandardInput.WriteLine($@"Germany.exe  aratedata/{file.Name}  aratedata/result{file.Name}");
                var output = cmd.StandardOutput;

                while (output.BaseStream.CanRead)
                {
                    var line = output.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (line.StartsWith("Return") && line.EndsWith("0"))
                    {
                        break;
                    }

                    Console.WriteLine($"i={c},output:{line}");
                }

                Console.WriteLine($"i={c} over...");
            });
            stopwatch.Stop();

            Console.WriteLine($"all over....{stopwatch.ElapsedMilliseconds}ms");
            CombineFiles();
            Console.ReadKey();
        }

        private static List<FileInfo> GenerateFiles()
        {
            var baseData = Path.Combine(CodeDirectory, "aratedata", "arate.dat");
            using var fileStream = new FileStream(baseData, FileMode.Open);
            using var streamReader = new StreamReader(fileStream, Encoding.Default);
            var text = streamReader.ReadToEnd();
            var lines = text.Split("\r\n");
            double[] rates = new double[14];
            for (int i = 0; i < lines.Length; i++)
            {
                var rateArray = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                rates[i] = Convert.ToDouble(rateArray[1]);
            }

            List<FileInfo> files = new List<FileInfo>();
            for (int jIndex = 0; jIndex < 100; jIndex++)
            {
                var random1 = new Random().Next(1, 10);
                var random2 = new Random().Next(1, 10);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 14; i++)
                {

                    if (i == 4)
                    {
                        var rate = 0.1185 + random1 * 0.0001;
                        sb.AppendFormat($"if(i.lt.it_alarm+{50})rate:    {rate}\r\n");
                    }
                    else if (i == 5)
                    {
                        var rate = 0.222 - 0.0001 * random2;
                        sb.AppendFormat($"if(i.lt.it_alarm+{45})rate:    {rate}\r\n");
                    }
                    else
                    {
                        var rate = rates[i];
                        sb.AppendFormat($"if(i.lt.it_alarm+{(70 - 5 * i)})rate:    {rate}\r\n");
                    }

                }
                var baseDataTemp = Path.Combine(CodeDirectory, "aratedata", $"arate{jIndex}.dat");
                files.Add(new FileInfo(baseDataTemp));
                using var fileStreamSource = new FileStream(baseDataTemp, FileMode.Create);
                using var streamWriter = new StreamWriter(fileStreamSource, Encoding.Default);
                streamWriter.Write(sb);
            }
            return files;
        }

        private static void CombineFiles()
        {
            var baseData = Path.Combine(CodeDirectory, "aratedata");
            var files = Directory.GetFiles(baseData, "result*.dat");

            var array = new int[files.Length, 200];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var fileInfo = new FileInfo(file);
                sb.AppendFormat($"{fileInfo.Name},");
                using var fileStream = new FileStream(file, FileMode.Open);
                using var streamReader = new StreamReader(fileStream, Encoding.Default);
                var text = streamReader.ReadToEnd();
                var lines = text.Split("\r\n");
                for (int j = 0; j < lines.Length; j++)
                {
                    var line = lines[j].Trim();
                    if (string.IsNullOrEmpty(line)) { continue; }
                    var val = Convert.ToInt32(line);
                    array[i, j] = val;
                }
            }

            sb.AppendFormat("\r\n");
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < files.Length; j++)
                {
                    sb.AppendFormat($"{array[j, i]},");
                }
                sb.AppendFormat("\r\n");
            }
            var baseDataTemp = Path.Combine(CodeDirectory, "aratedata", "arateresult.csv");
            using var fileStreamSource = new FileStream(baseDataTemp, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStreamSource, Encoding.Default);
            streamWriter.Write(sb);
        }
    }
}
