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

        private readonly List<string> _parameters = new List<string>()
        {
            "Ph1","Ph2","Pv"
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            Cb_MaximumParameter.DataSource = _parameters.ToList();
            Cb_MediumParameter.DataSource = _parameters.ToList();
            Cb_MinimumParameter.DataSource = _parameters.ToList();

            Cb_MaximumParameter.SelectedItem = _parameters.First(c => c == "Ph1");
            Cb_MediumParameter.SelectedItem = _parameters.First(c => c == "Ph2");
            Cb_MinimumParameter.SelectedItem = _parameters.First(c => c == "Pv");
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

            var maximum = Cb_MaximumParameter.SelectedItem.ToString().ToLower();
            var medium = Cb_MediumParameter.SelectedItem.ToString().ToLower();
            var minimum = Cb_MinimumParameter.SelectedItem.ToString().ToLower();

            if (maximum == medium || medium == minimum || maximum == minimum)
            {
                MessageBox.Show("大小关系选择不能重复", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MaximumValue = Cb_MaximumParameter.SelectedItem.ToString(),
                MediumValue = Cb_MediumParameter.SelectedItem.ToString(),
                MinimumValue = Cb_MinimumParameter.SelectedItem.ToString(),
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
            var temp = dataList.Where(c => c.DataType == DataType.Erlei).ToList();
            Lb_Total.Text = temp.Count().ToString();
            Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                var result = Parallel.ForEach(temp, inputData =>
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

                    Lb_Finished.Invoke(new Action(() =>
                    {
                        Lb_Finished.Text = _recordStack.Count(c => c.T > 0 || c.T < 0).ToString();
                    }));

                    Lb_TotalTime.Invoke(new Action(() =>
                    {
                        Lb_TotalTime.Text = $"(耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)";
                    }));
                });

                Btn_Calcualte.Invoke(new Action(() =>
                {
                    Btn_Calcualte.Enabled = true;
                    Btn_Calcualte.Text = "计算";
                }));

                var fileInfo = new FileInfo(path);
                var savedFile = Path.Combine(fileInfo.DirectoryName, "result.dat");
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
