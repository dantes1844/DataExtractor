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

        private CalculateBase GetCalculator(string maximum, string medium, string minimum)
        {
            switch ($"{maximum}_{medium}_{minimum}")
            {
                case "ph1_ph2_pv":
                    return new Ph1Ph2Pv();
                case "ph1_pv_ph2":
                    return new Ph1PvPh2();
                case "ph2_ph1_pv":
                    return new Ph2Ph1Pv();
                case "ph2_pv_ph1":
                    return new Ph2PvPh1();
                case "pv_ph1_ph2":
                    return new PvPh1Ph2();
                case "pv_ph2_ph1":
                    return new PvPh2Ph1();
                default:
                    return null;
            }
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

            Lb_Total.Text = dataList.Count.ToString();

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

            if (!double.TryParse(Tb_RandomNumberStart.Text, out double randomNumberStart))
            {
                MessageBox.Show("随机数下限必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_RandomNumberStart.Focus();
                return;
            }

            if (!double.TryParse(Tb_RandomNumberEnd.Text, out double randomNumberEnd))
            {
                MessageBox.Show("随机数上限必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_RandomNumberEnd.Focus();
                return;
            }

            if (randomNumberStart >= randomNumberEnd)
            {
                MessageBox.Show("随机数上限必须大于下限", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_RandomNumberEnd.Focus();
                return;
            }

            CalculateConfig config = new CalculateConfig()
            {
                MaximumValue = Cb_MaximumParameter.SelectedItem.ToString(),
                MediumValue = Cb_MediumParameter.SelectedItem.ToString(),
                MinimumValue = Cb_MinimumParameter.SelectedItem.ToString(),
                DefaultDeviation = deviation,
                LoopCount = loopCount * 10000,
                RandomNumberEnd = randomNumberEnd,
                RandomNumberStart = randomNumberStart
            };
            double sameRandomNumber = 0d;
            if (Rb_RandomPerRecord.Checked)
            {
                config.RandomNumberType = RandomNumberType.RandomNumberPerRecord;
            }
            else if (Rb_SameRandom.Checked)
            {
                var random = new Random();
                sameRandomNumber = (config.RandomNumberEnd - config.RandomNumberStart) * random.NextDouble() + config.RandomNumberStart;
                config.RandomNumberType = RandomNumberType.SameRandomNumber;
            }

            Btn_Calcualte.Enabled = false;
            Btn_Calcualte.Text = "正在计算...";
            Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                var result = Parallel.ForEach(dataList, inputData =>
                {
                    if (config.RandomNumberType == RandomNumberType.RandomNumberPerRecord)
                    {
                        var random = new Random();
                        inputData.RandP = (config.RandomNumberEnd - config.RandomNumberStart) * random.NextDouble() + config.RandomNumberStart;
                    }
                    else
                    {
                        inputData.RandP = sameRandomNumber;
                    }

                    var service = GetCalculator(maximum, medium, minimum);
                    service.ParallelRun(config, inputData);
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

                if (result.IsCompleted)
                {
                    Lb_Finished.Invoke(new Action(() =>
                    {
                        Lb_Finished.Text = _recordStack.Count(c => c.T > 0 || c.T < 0).ToString();
                    }));
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

                }
            });
        }

        private void Cb_MaximumParameter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
