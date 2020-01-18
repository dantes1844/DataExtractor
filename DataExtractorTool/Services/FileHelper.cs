using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataExtractorTool.Services
{
    public class FileHelper
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

        public static void SaveBaseData(string defaultFile, List<InputData> list, ResultSaveType resultSaveType)
        {
            var csvText = new StringBuilder();
            var txtText = new StringBuilder();

            txtText.Append($"No.\ttype\tS1\tS2\tS3\tdr\trp\tx\tt\tph1\tph2\tpv{Environment.NewLine}");
            csvText.Append($"No.,type,S1,S2,S3,dr,rp,x,t,ph1,ph2,pv{Environment.NewLine}");
            if (list.Any())
            {
                foreach (var item in list)
                {
                    switch (resultSaveType)
                    {
                        case ResultSaveType.All:
                            txtText.AppendFormat($"{item.ToTextString()}{Environment.NewLine}");
                            csvText.AppendFormat($"{item.ToCsvString()}{Environment.NewLine}");
                            break;
                        case ResultSaveType.Csv:
                            csvText.AppendFormat($"{item.ToCsvString()}{Environment.NewLine}");
                            break;
                        case ResultSaveType.Txt:
                            txtText.AppendFormat($"{item.ToTextString()}{Environment.NewLine}");
                            break;
                    }
                }
            }

            switch (resultSaveType)
            {
                case ResultSaveType.All:
                    SaveFile(defaultFile, txtText.ToString());
                    SaveFile(defaultFile + ".csv", csvText.ToString());
                    break;
                case ResultSaveType.Csv:
                    SaveFile(defaultFile + ".csv", csvText.ToString());
                    break;
                case ResultSaveType.Txt:
                    SaveFile(defaultFile, txtText.ToString());
                    break;
            }
        }

        private static void SaveFile(string path, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (var sr = new StreamWriter(fs))
                {
                    sr.Write(text);
                }
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}