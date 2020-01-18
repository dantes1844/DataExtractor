using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataExtractorTool.Models;
using DataExtractorTool.Services;

namespace DataExtractorTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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

            Cb_ResultSaveType.DataSource = Enum.GetValues(typeof(ResultSaveType));
        }

        private void Btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (Rb_SingleFile.Checked)
            {
                var fileDialog = new OpenFileDialog();
                var dialogResult = fileDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                Tb_SourceDataPath.Text = fileDialog.FileName;
            }
            else if (Rb_MulitpleFiles.Checked)
            {
                var fileDialog = new FolderBrowserDialog()
                {
                    SelectedPath = AppDomain.CurrentDomain.BaseDirectory
                };

                var dialogResult = fileDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                Tb_SourceDataPath.Text = fileDialog.SelectedPath;
            }
        }


        private ConcurrentBag<InputData> _recordStack;
        private const int LoopCountBase = 10000;

        private void Btn_Calcualte_Click(object sender, EventArgs e)
        {
            var config = new CalculateConfig();
            #region 差值

            if (!double.TryParse(Tb_Ph2MinusPv.Text, out double deviation))
            {
                MessageBox.Show("差值必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_Ph2MinusPv.Focus();
                return;
            }
            config.DefaultDeviation = deviation;

            #endregion

            #region X值

            if (double.TryParse(Tb_TypeOneDefaultX.Text, out double typeOneDefaultX))
            {
                config.TypeOneDefaultX = typeOneDefaultX;
            }

            if (double.TryParse(Tb_TypeTwoDefaultX.Text, out double typeTwoDefaultX))
            {
                config.TypeTwoDefaultX = typeTwoDefaultX;
            }

            if (double.TryParse(Lb_TypeThreeDefaultX.Text, out double typeThreeDefaultX))
            {
                config.TypeThreeDefaultX = typeThreeDefaultX;
            }

            #endregion

            #region 修正值

            if (!double.TryParse(Tb_TypeOneIncreaseNumber.Text, out double oneIncrease))
            {
                MessageBox.Show("一类修正值必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeOneIncreaseNumber.Focus();
                return;
            }
            config.YileiIncreaseNumber = oneIncrease;

            if (!double.TryParse(Tb_TypeTwoIncreaseNumber.Text, out double twoIncrease))
            {
                MessageBox.Show("二类修正值必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeTwoIncreaseNumber.Focus();
                return;
            }
            config.ErleiIncreaseNumber = twoIncrease;

            if (!double.TryParse(Tb_TypeThreeIncreaseNumber.Text, out double threeIncrease))
            {
                MessageBox.Show("三类修正值必须是个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeThreeIncreaseNumber.Focus();
                return;
            }
            config.SanleiIncreaseNumber = threeIncrease;

            #endregion

            #region 次数

            if (!int.TryParse(Tb_TypeOneLoopCount.Text, out var oneLoopCount))
            {
                MessageBox.Show("一类遍历次数必须是个正数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeOneLoopCount.Focus();
                return;
            }
            config.YileiLoopCount = oneLoopCount * LoopCountBase;

            if (!int.TryParse(Tb_TypeTwoLoopCount.Text, out var twoLoopCount))
            {
                MessageBox.Show("二类遍历次数必须是个正数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeTwoLoopCount.Focus();
                return;
            }
            config.ErleiLoopCount = twoLoopCount * LoopCountBase;

            if (!int.TryParse(Tb_TypeThreeLoopCount.Text, out var threeLoopCount))
            {
                MessageBox.Show("三类遍历次数必须是个正数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_TypeThreeLoopCount.Focus();
                return;
            }
            config.SanleiLoopCount = threeLoopCount * LoopCountBase;

            #endregion

            #region 配置项


            if (Rb_RandomPerRecord.Checked)
            {
                config.RandomNumberType = RandomNumberType.RandomNumberPerRecord;
            }
            else if (Rb_SameRandom.Checked)
            {
                config.RandomNumberType = RandomNumberType.SameRandomNumber;
                var random = new Random();
                _sameRandomNumber1 = (170 - 150) * random.NextDouble() + 150;
                _sameRandomNumber2 = (190 - 170) * random.NextDouble() + 170;
                _sameRandomNumber3 = (210 - 190) * random.NextDouble() + 190;
            }

            #endregion

            #region t的最小值

            if (double.TryParse(Tb_TValue.Text, out var tValue))
            {
                config.TMinimumValue = tValue;
            }

            #endregion

            Lb_TotalTime.Text = "";
            Lb_Total.Text = "0";
            Lb_Finished.Text = "0";

            if (Rb_SingleFile.Checked)
            {
                SingleFile(config);
            }
            else if (Rb_MulitpleFiles.Checked)
            {
                MulitipleFile(config);
            }
        }

        double _sameRandomNumber1;
        double _sameRandomNumber3;
        double _sameRandomNumber2;


        private void SingleFile(CalculateConfig config)
        {
            _recordStack = new ConcurrentBag<InputData>();
            var resultSaveType = (ResultSaveType)Cb_ResultSaveType.SelectedValue;

            #region 路径

            var path = Tb_SourceDataPath.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("路径不能空撒", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_SourceDataPath.Focus();
                return;
            }

            var dataList = FileHelper.ReadBaseData(path);
            if (dataList.Count == 0)
            {
                MessageBox.Show("指定的文件没有读取到合法数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region 计算

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
                        Calculate(inputData, config);

                        if (_recordStack.Count % 1000 == 0)
                        {
                            Lb_Finished.Invoke(new Action(() => { Lb_Finished.Text = _recordStack.Count(c => c.T > 0 || c.T < 0).ToString(); }));

                            Lb_TotalTime.Invoke(new Action(() => { Lb_TotalTime.Text = $"(耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)"; }));
                            Debug.WriteLine($"当前执行完成了{_recordStack.Count}.耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)");
                        }
                    });
                }

                Lb_Finished.Invoke(new Action(() => { Lb_Finished.Text = _recordStack.Count().ToString(); }));

                var savedFile = SaveFile(path, dataList, resultSaveType);

                //文件已经保存了再设置按钮的可用状态
                Btn_Calcualte.Invoke(new Action(() =>
                {
                    Btn_Calcualte.Enabled = true;
                    Btn_Calcualte.Text = "计算";
                }));

                Lb_TotalTime.Invoke(new Action(() =>
                {
                    Lb_TotalTime.Text = string.IsNullOrEmpty(Lb_TotalTime.Text)
                        ? "计算完毕，请查看文件内容."
                        : Lb_TotalTime.Text.Insert(1, "计算完毕，请查看文件内容.");
                }));

                var openFileConfirm = MessageBox.Show("计算完成。是否打开结果文件夹", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (openFileConfirm == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", $@"/select,{savedFile}");
                }
            });

            #endregion
        }

        private static string SaveFile(string path, List<InputData> dataList, ResultSaveType resultSaveType)
        {
            var fileInfo = new FileInfo(path);
            var dotPosition = fileInfo.Name.LastIndexOf(".");

            var savedFile = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name.Insert(dotPosition, ".result")}");
            if (dotPosition < 0)
            {
                savedFile = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}.result.dat");
            }

            FileHelper.SaveBaseData(savedFile, dataList, resultSaveType);
            return savedFile;
        }

        private void Calculate(InputData inputData, CalculateConfig config)
        {
            CalculateBase service;
            switch (inputData.DataType)
            {
                case DataType.Yilei:
                    inputData.RandP = _sameRandomNumber1;
                    service = new Ph1Ph2Pv();
                    break;
                case DataType.Erlei:
                    inputData.RandP = _sameRandomNumber2;
                    service = new Ph1PvPh2();
                    break;
                case DataType.Sanlei:
                    inputData.RandP = _sameRandomNumber3;
                    service = new PvPh1Ph2();
                    break;
                default:
                    service = null;
                    break;
            }

            if (config.RandomNumberType == RandomNumberType.RandomNumberPerRecord)
            {
                var random = new ThreadSafeRandom();
                var rp = (inputData.RandomNumberEnd - inputData.RandomNumberStart) * random.NextDouble();
                inputData.RandP = rp + inputData.RandomNumberStart;
            }

            service?.ParallelRun(config, inputData);
            _recordStack.Add(inputData);
        }

        private void MulitipleFile(CalculateConfig config)
        {
            #region 路径

            var selectedDirectory = Tb_SourceDataPath.Text.Trim();
            if (string.IsNullOrEmpty(selectedDirectory))
            {
                MessageBox.Show("路径不能空撒", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tb_SourceDataPath.Focus();
                return;
            }

            #endregion

            var resultSaveType = (ResultSaveType)Cb_ResultSaveType.SelectedValue;
            Btn_Calcualte.Enabled = false;
            Btn_Calcualte.Text = "正在计算...";
            var type = (int)Cb_DataType.SelectedValue;

            Task.Run(() =>
             {
                 var files = Directory.GetFiles(selectedDirectory, "*.dat");
                 foreach (var file in files)
                 {
                     _recordStack = new ConcurrentBag<InputData>();

                     var fileinfo = new FileInfo(file);

                     var dataList = FileHelper.ReadBaseData(file);

                     #region 计算

                     Debug.WriteLine($"file:{fileinfo.Name}.一类:{dataList.Count(c => c.DataType == DataType.Yilei)},二类:{dataList.Count(c => c.DataType == DataType.Erlei)},三类:{dataList.Count(c => c.DataType == DataType.Sanlei)}");
                     if (type > 0)
                     {
                         var dataType = (DataType)type;
                         dataList = dataList.Where(c => c.DataType == dataType).ToList();
                     }
                     Lb_Total.Invoke(new Action(() =>
                     {
                         Lb_Total.Text = dataList.Count.ToString();
                     }));

                     Stopwatch stopwatch = Stopwatch.StartNew();

                     Parallel.ForEach(dataList, inputData =>
                     {
                         Calculate(inputData, config);

                         Lb_Finished.Invoke(new Action(() => { Lb_Finished.Text = _recordStack.Count(c => c.T > 0 || c.T < 0).ToString(); }));
                         Lb_TotalTime.Invoke(new Action(() => { Lb_TotalTime.Text = $"(正在计算:{fileinfo.Name})"; }));
                         Debug.WriteLine($"正在计算{fileinfo.Name},当前执行完成了{_recordStack.Count}.耗时:{stopwatch.ElapsedMilliseconds / 1000.0}s)");
                     });

                     Lb_Finished.Invoke(new Action(() => { Lb_Finished.Text = _recordStack.Count().ToString(); }));

                     SaveFile(file, dataList, resultSaveType);

                     #endregion
                 }
             }).ContinueWith(task =>
            {
                //文件已经保存了再设置按钮的可用状态
                Btn_Calcualte.Invoke(new Action(() =>
                {
                    Btn_Calcualte.Enabled = true;
                    Btn_Calcualte.Text = "计算";
                }));
                Lb_TotalTime.Invoke(new Action(() => { Lb_TotalTime.Text = "计算完毕，请查看文件内容"; }));
                Lb_Total.Invoke(new Action(() => { Lb_Total.Text = "0"; }));
                Lb_Finished.Invoke(new Action(() => { Lb_Finished.Text = "0"; }));

                var openFileConfirm = MessageBox.Show("计算完成。是否打开结果文件夹", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (openFileConfirm == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", selectedDirectory);
                }
            });
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            FileHelper.SaveBaseData(@"D:\yujian\test.data", new List<InputData>(), ResultSaveType.All);
            var service = new PvPh1Ph2();
            var random = new Random();
            var sameRandomNumber1 = (170 - 150) * random.NextDouble() + 150;
            var sameRandomNumber2 = (190 - 170) * random.NextDouble() + 170;
            var sameRandomNumber3 = (210 - 190) * random.NextDouble() + 190;
            var inputData = new InputData()
            {
                DataType = DataType.Erlei,
                S1 = 279.6,
                S2 = -1309.7,
                S3 = -226.6,
                Dr = 2.4871,
                RandP = sameRandomNumber3
            };
            service.FindOne(inputData);
        }

        private void Rb_SingleFile_CheckedChanged(object sender, EventArgs e)
        {
            Btn_OpenFile.Text = "选择文件";
            Tb_SourceDataPath.Text = "";
        }

        private void Rb_MulitpleFiles_CheckedChanged(object sender, EventArgs e)
        {
            Btn_OpenFile.Text = "选择文件夹";
            Tb_SourceDataPath.Text = "";
        }
    }
}
