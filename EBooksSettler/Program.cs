using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace EBooksSettler
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = ConfigurationManager.AppSettings["FolderPath"];


            var directories = Directory.GetDirectories(folderPath);

            StringBuilder sb = new StringBuilder();
            foreach (var directory in directories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                sb.AppendFormat($"{directoryInfo.Name}{Environment.NewLine}");

                var files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    if (file.EndsWith(".pdf"))
                    {
                        var fileInfo = new FileInfo(file);
                        sb.AppendFormat($"\t{fileInfo.Name}{Environment.NewLine}");

                    }
                }
            }

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
