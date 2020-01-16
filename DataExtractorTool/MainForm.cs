using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataExtractorTool.Services;

namespace DataExtractorTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        class DataTypeList
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cb_DataType.DataSource = new List<DataTypeList>()
            {
                new DataTypeList(){Name = "全部",Value = 0},
                new DataTypeList(){Name = "一类",Value =  (int)DataType.Yilei},
                new DataTypeList(){Name = "二类",Value = (int)DataType.Erlei},
                new DataTypeList(){Name = "三类",Value = (int)DataType.Sanlei},
            };
            Cb_DataType.DisplayMember = nameof(DataTypeList.Name);
            Cb_DataType.ValueMember = nameof(DataTypeList.Value);
        }

        private void Btn_OpenFile_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            Tb_SourceDataPath.Text = fileDialog.FileName;
        }


        private ConcurrentBag<InputData> _recordStack;
        private void Btn_Calcualte_Click(object sender, EventArgs e)
        {
            _recordStack = new ConcurrentBag<InputData>();

            var path = Tb_SourceDataPath.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("路径不能空撒", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_SourceDataPath.Focus();
                return;
            }
            var dataList = FileReader.ReadBaseData(path);
            if (dataList.Count == 0)
            {
                MessageBox.Show("指定的文件没有读取到合法数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!double.TryParse(Tb_Ph2MinusPv.Text, out double deviation))
            {
                MessageBox.Show("差值必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(Tb_LoopCount.Text, out var loopCount))
            {
                MessageBox.Show("遍历次数必须是个正数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CalculateConfig config = new CalculateConfig()
            {
                DefaultDeviation = deviation,
                LoopCount = loopCount * 10000
            };
            double sameRandomNumber1 = 0d;
            double sameRandomNumber3 = 0d;
            double sameRandomNumber2 = 0d;
            if (Rb_RandomPerRecord.Checked)
            {
                config.RandomNumberType = RandomNumberType.RandomNumberPerRecord;
            }
            else if (Rb_SameRandom.Checked)
            {
                config.RandomNumberType = RandomNumberType.SameRandomNumber;
                var random = new Random();
                sameRandomNumber1 = (170 - 150) * random.NextDouble() + 150;
                sameRandomNumber2 = (190 - 170) * random.NextDouble() + 170;
                sameRandomNumber3 = (210 - 190) * random.NextDouble() + 190;
            }

            Btn_Calcualte.Enabled = false;
            Btn_Calcualte.Text = "正在计算...";

            Debug.WriteLine($"一类:{dataList.Count(c => c.DataType == DataType.Yilei)},二类:{dataList.Count(c => c.DataType == DataType.Erlei)},三类:{dataList.Count(c => c.DataType == DataType.Sanlei)}");
            var type = (int)Cb_DataType.SelectedValue;
            if (type > 0)
            {
                var dataType = (DataType)type;
                dataList = dataList.Where(c => c.DataType == dataType).ToList();
            }

            Lb_Total.Text = dataList.Count().ToString();
            Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                var total = 30;
                var average = Math.DivRem(dataList.Count, total, out var mod);
                if (mod != 0)
                {
                    average += total;
                }

                for (int j = 0; j < total; j++)
                {
                    var subTemp = dataList.Skip(j * average).Take(average).ToList();
                    Debug.WriteLine($"j={j},count={subTemp.Count}");

                    var result = Parallel.ForEach(subTemp, inputData =>
                    {
                        CalculateBase service;
                        switch (inputData.DataType)
                        {
                            case DataType.Yilei:
                                inputData.RandP = sameRandomNumber1;
                                service = new Ph1Ph2Pv();
                                break;
                            case DataType.Erlei:
                                inputData.RandP = sameRandomNumber2;
                                service = new Ph1PvPh2();
                                break;
                            case DataType.Sanlei:
                                inputData.RandP = sameRandomNumber3;
                                service = new PvPh1Ph2();
                                break;
                            default:
                                service = null;
                                break;
                        }

                        if (config.RandomNumberType == RandomNumberType.RandomNumberPerRecord)
                        {
                            var random = new Random();
                            inputData.RandP = (inputData.RandomNumberEnd - inputData.RandomNumberStart) * random.NextDouble() + inputData.RandomNumberStart;
                        }

                        service?.ParallelRun(config, inputData);
                        if (!_recordStack.Contains(inputData)) { _recordStack.Add(inputData); }

                        
                        if (_recordStack.Count % 1000 == 0)
                        {
                            Lb_Finished.Invoke(new Action(() =>
                            {
                                Lb_Finished.Text = _recordStack.Count(c => c.T > 0 || c.T < 0).ToString();
                            }));

                            Lb_TotalTime.Invoke(new Action(() =>
                            {
                                Lb_TotalTime.Text = $"(耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)";
                            }));
                            Debug.WriteLine($"当前执行完成了{_recordStack.Count}.耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)");
                        }

                    });
                }

                Btn_Calcualte.Invoke(new Action(() =>
                {
                    Btn_Calcualte.Enabled = true;
                    Btn_Calcualte.Text = "计算";
                }));

                var fileInfo = new FileInfo(path);
                var savedFile = Path.Combine(fileInfo.DirectoryName, "result.csv");
                FileReader.SaveBaseData(savedFile, dataList);

                var openFileConfirm = MessageBox.Show($"计算完成。是否打开结果文件夹", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (openFileConfirm == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", $@"/select,{savedFile}");
                }
            });
        }

        private void Cb_MaximumParameter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileReader.SaveBaseData(@"D:\yujian\test.csv", new List<InputData>());
            var service = new Ph1PvPh2();
            var random = new Random();
            var sameRandomNumber1 = (170 - 150) * random.NextDouble() + 150;
            var sameRandomNumber2 = (190 - 170) * random.NextDouble() + 170;
            var sameRandomNumber3 = (210 - 190) * random.NextDouble() + 190;
            var inputData = new InputData()
            {
                DataType = DataType.Erlei,
                S1 = 694.6,
                S2 = -663.2,
                S3 = 6.9,
                Dr = 2.2723,
                RandP = sameRandomNumber2
            };
            service.FindOne(inputData);
        }
    }
}
