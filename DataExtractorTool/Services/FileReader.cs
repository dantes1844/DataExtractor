using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataExtractorTool.Services
{
    public class FileReader
    {
        public static List<InputData> ReadBaseData(string defaultFile)
        {
            if (string.IsNullOrEmpty(defaultFile))
            {
                return new List<InputData>();
            }

            if (!File.Exists(defaultFile))
            {
                return new List<InputData>();
            }
            using (FileStream fs = new FileStream(defaultFile, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                try
                {
                    var index = 1;
                    List<InputData> list = new List<InputData>();
                    var text = sr.ReadToEnd();

                    var lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int pointNumber = 1;
                    foreach (var line in lines)
                    {
                        if (index++ == 1) { continue; }
                        var array = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (array.Length == 4)
                        {
                            list.Add(new InputData()
                            {
                                PointNumber = pointNumber++,
                                S1 = Convert.ToDouble(array[0]),
                                S2 = Convert.ToDouble(array[1]),
                                S3 = Convert.ToDouble(array[2]),
                                Dr = Convert.ToDouble(array[3]),
                            });
                        }
                        else if (array.Length == 5)
                        {
                            list.Add(new InputData()
                            {
                                PointNumber = Convert.ToInt32(array[0]),
                                S1 = Convert.ToDouble(array[1]),
                                S2 = Convert.ToDouble(array[2]),
                                S3 = Convert.ToDouble(array[3]),
                                Dr = Convert.ToDouble(array[4]),
                            });
                        }
                        else if (array.Length == 6)
                        {
                            list.Add(new InputData()
                            {
                                PointNumber = Convert.ToInt32(array[0]),
                                DataType = (DataType)Convert.ToInt32(array[1]),
                                S1 = Convert.ToDouble(array[2]),
                                S2 = Convert.ToDouble(array[3]),
                                S3 = Convert.ToDouble(array[4]),
                                Dr = Convert.ToDouble(array[5]),
                            });
                        }
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    return new List<InputData>();
                }
            }
        }

        public static void SaveBaseData(string defaultFile, List<InputData> list)
        {
            var text = new StringBuilder();
            foreach (var item in list)
            {
                text.AppendFormat($"{item.PointNumber}    {item.S1:F4}  {item.S2:F4}  {item.S3:F4}    {item.RandP:F4}  {item.X:F4}  {item.T:F4}  {item.Ph1:F4}  {item.Ph2:F4}  {item.Pv:F4}\r\n");
            }

            using (FileStream fs = new FileStream(defaultFile, FileMode.Create))
            using (var sr = new StreamWriter(fs))
            {
                sr.Write(text.ToString());
            }
        }
    }
}