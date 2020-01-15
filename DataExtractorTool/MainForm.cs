using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataExtractor.Services;

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

        private void Btn_Calcualte_Click(object sender, EventArgs e)
        {
            var path = Tb_SourceDataPath.Text.Trim();
            var dataList = FileReader.ReadBaseData(path);
            if (dataList.Count == 0)
            {
                MessageBox.Show("指定的文件没有读取到合法数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task.Run(() =>
            {
                CaculateService.ParallelRun(dataList);

                var fileInfo = new FileInfo(path);
                var savedFile = Path.Combine(fileInfo.DirectoryName, "result.dat");
                FileReader.SaveBaseData(savedFile, dataList);

                MessageBox.Show("计算完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void Cb_MaximumParameter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
