using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataExtractor
{
    public class FileReader
    {
        public static List<InputData> ReadBaseData()
        {
            var defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testdata.dat");
            using (FileStream fs = new FileStream(defaultFile, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                List<InputData> list = new List<InputData>();
                var text = sr.ReadToEnd();

                var lines = text.Split("\r\n");
                int pointNumber = 1;
                foreach (var line in lines)
                {
                    var array = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (array.Length != 4)
                    {
                        continue;
                    }
                    list.Add(new InputData()
                    {
                        PointNumber = pointNumber++,
                        S1 = Convert.ToDouble(array[0]),
                        S2 = Convert.ToDouble(array[1]),
                        S3 = Convert.ToDouble(array[2]),
                        Dr = Convert.ToDouble(array[3]),
                    });
                }

                return list;
            }
        }
        public static void SaveBaseData(List<InputData> list)
        {
            var text = new StringBuilder();
            foreach (var item in list)
            {
                text.AppendFormat($"{item.PointNumber}    {item.S1:F4}  {item.S2:F4}  {item.S3:F4}    {item.RandP}  {item.X:F4}  {item.T:F4}  {item.Ph1:F4}  {item.Ph2:F4}  {item.Pv:F4}\r\n");
            }

            var defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.dat");
            using (FileStream fs = new FileStream(defaultFile, FileMode.OpenOrCreate))
            using (var sr = new StreamWriter(fs))
            {
                sr.Write(text.ToString());
            }
        }
    }
}