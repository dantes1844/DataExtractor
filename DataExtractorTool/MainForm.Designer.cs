namespace DataExtractorTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LB_DataSource = new System.Windows.Forms.Label();
            this.Tb_SourceDataPath = new System.Windows.Forms.TextBox();
            this.Btn_OpenFile = new System.Windows.Forms.Button();
            this.Tb_Ph2MinusPv = new System.Windows.Forms.TextBox();
            this.Btn_Calcualte = new System.Windows.Forms.Button();
            this.Lb_DefaultValue = new System.Windows.Forms.Label();
            this.LB_RandomWay = new System.Windows.Forms.Label();
            this.Rb_RandomPerRecord = new System.Windows.Forms.RadioButton();
            this.Rb_SameRandom = new System.Windows.Forms.RadioButton();
            this.Lb_Finished = new System.Windows.Forms.Label();
            this.Lb_Progress = new System.Windows.Forms.Label();
            this.Lb_Slash = new System.Windows.Forms.Label();
            this.Lb_Total = new System.Windows.Forms.Label();
            this.Lb_TotalTime = new System.Windows.Forms.Label();
            this.Lb_LoopCount = new System.Windows.Forms.Label();
            this.Tb_TypeOneLoopCount = new System.Windows.Forms.TextBox();
            this.LB_LoopCountUnit = new System.Windows.Forms.Label();
            this.Btn_Debug = new System.Windows.Forms.Button();
            this.Lb_DataType = new System.Windows.Forms.Label();
            this.Cb_DataType = new System.Windows.Forms.ComboBox();
            this.Lb_TypeOneDeviation = new System.Windows.Forms.Label();
            this.Tb_TypeOneIncreaseNumber = new System.Windows.Forms.TextBox();
            this.Lb_TypeTwo = new System.Windows.Forms.Label();
            this.Tb_TypeTwoLoopCount = new System.Windows.Forms.TextBox();
            this.Lb_TypeTwoLoopCountUnit = new System.Windows.Forms.Label();
            this.Lb_TypeTwoDeviation = new System.Windows.Forms.Label();
            this.Tb_TypeTwoIncreaseNumber = new System.Windows.Forms.TextBox();
            this.Lb_TypeThreeLoopCount = new System.Windows.Forms.Label();
            this.Tb_TypeThreeLoopCount = new System.Windows.Forms.TextBox();
            this.Lb_TypeThreeLoopCountUnit = new System.Windows.Forms.Label();
            this.Lb_TypeThreeDeviation = new System.Windows.Forms.Label();
            this.Tb_TypeThreeIncreaseNumber = new System.Windows.Forms.TextBox();
            this.Lb_ComputeType = new System.Windows.Forms.Label();
            this.Rb_SingleFile = new System.Windows.Forms.RadioButton();
            this.Rb_MulitpleFiles = new System.Windows.Forms.RadioButton();
            this.Gb_FileType = new System.Windows.Forms.GroupBox();
            this.Gb_RandomType = new System.Windows.Forms.GroupBox();
            this.Lb_ResultSaveType = new System.Windows.Forms.Label();
            this.Cb_ResultSaveType = new System.Windows.Forms.ComboBox();
            this.Lb_TValue = new System.Windows.Forms.Label();
            this.Tb_TValue = new System.Windows.Forms.TextBox();
            this.Gb_FileType.SuspendLayout();
            this.Gb_RandomType.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_DataSource
            // 
            this.LB_DataSource.AutoSize = true;
            this.LB_DataSource.Location = new System.Drawing.Point(52, 56);
            this.LB_DataSource.Name = "LB_DataSource";
            this.LB_DataSource.Size = new System.Drawing.Size(59, 12);
            this.LB_DataSource.TabIndex = 0;
            this.LB_DataSource.Text = "原始数据:";
            // 
            // Tb_SourceDataPath
            // 
            this.Tb_SourceDataPath.Location = new System.Drawing.Point(117, 53);
            this.Tb_SourceDataPath.Name = "Tb_SourceDataPath";
            this.Tb_SourceDataPath.Size = new System.Drawing.Size(246, 21);
            this.Tb_SourceDataPath.TabIndex = 1;
            // 
            // Btn_OpenFile
            // 
            this.Btn_OpenFile.Location = new System.Drawing.Point(369, 53);
            this.Btn_OpenFile.Name = "Btn_OpenFile";
            this.Btn_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenFile.TabIndex = 2;
            this.Btn_OpenFile.Text = "选择文件";
            this.Btn_OpenFile.UseVisualStyleBackColor = true;
            this.Btn_OpenFile.Click += new System.EventHandler(this.Btn_OpenFile_Click);
            // 
            // Tb_Ph2MinusPv
            // 
            this.Tb_Ph2MinusPv.Location = new System.Drawing.Point(116, 89);
            this.Tb_Ph2MinusPv.Name = "Tb_Ph2MinusPv";
            this.Tb_Ph2MinusPv.Size = new System.Drawing.Size(57, 21);
            this.Tb_Ph2MinusPv.TabIndex = 11;
            this.Tb_Ph2MinusPv.Text = "2";
            // 
            // Btn_Calcualte
            // 
            this.Btn_Calcualte.Location = new System.Drawing.Point(356, 373);
            this.Btn_Calcualte.Name = "Btn_Calcualte";
            this.Btn_Calcualte.Size = new System.Drawing.Size(88, 41);
            this.Btn_Calcualte.TabIndex = 14;
            this.Btn_Calcualte.Text = "计算";
            this.Btn_Calcualte.UseVisualStyleBackColor = true;
            this.Btn_Calcualte.Click += new System.EventHandler(this.Btn_Calcualte_Click);
            // 
            // Lb_DefaultValue
            // 
            this.Lb_DefaultValue.AutoSize = true;
            this.Lb_DefaultValue.Location = new System.Drawing.Point(51, 92);
            this.Lb_DefaultValue.Name = "Lb_DefaultValue";
            this.Lb_DefaultValue.Size = new System.Drawing.Size(59, 12);
            this.Lb_DefaultValue.TabIndex = 15;
            this.Lb_DefaultValue.Text = "默认差值:";
            // 
            // LB_RandomWay
            // 
            this.LB_RandomWay.AutoSize = true;
            this.LB_RandomWay.Location = new System.Drawing.Point(39, 228);
            this.LB_RandomWay.Name = "LB_RandomWay";
            this.LB_RandomWay.Size = new System.Drawing.Size(71, 12);
            this.LB_RandomWay.TabIndex = 16;
            this.LB_RandomWay.Text = "随机数规则:";
            // 
            // Rb_RandomPerRecord
            // 
            this.Rb_RandomPerRecord.AutoSize = true;
            this.Rb_RandomPerRecord.Location = new System.Drawing.Point(134, 16);
            this.Rb_RandomPerRecord.Name = "Rb_RandomPerRecord";
            this.Rb_RandomPerRecord.Size = new System.Drawing.Size(83, 16);
            this.Rb_RandomPerRecord.TabIndex = 17;
            this.Rb_RandomPerRecord.Text = "按记录随机";
            this.Rb_RandomPerRecord.UseVisualStyleBackColor = true;
            // 
            // Rb_SameRandom
            // 
            this.Rb_SameRandom.AutoSize = true;
            this.Rb_SameRandom.Checked = true;
            this.Rb_SameRandom.Location = new System.Drawing.Point(6, 16);
            this.Rb_SameRandom.Name = "Rb_SameRandom";
            this.Rb_SameRandom.Size = new System.Drawing.Size(119, 16);
            this.Rb_SameRandom.TabIndex = 18;
            this.Rb_SameRandom.TabStop = true;
            this.Rb_SameRandom.Text = "使用同一个随机数";
            this.Rb_SameRandom.UseVisualStyleBackColor = true;
            // 
            // Lb_Finished
            // 
            this.Lb_Finished.AutoSize = true;
            this.Lb_Finished.Location = new System.Drawing.Point(118, 342);
            this.Lb_Finished.Name = "Lb_Finished";
            this.Lb_Finished.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lb_Finished.Size = new System.Drawing.Size(11, 12);
            this.Lb_Finished.TabIndex = 19;
            this.Lb_Finished.Text = "0";
            this.Lb_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lb_Progress
            // 
            this.Lb_Progress.AutoSize = true;
            this.Lb_Progress.Location = new System.Drawing.Point(51, 342);
            this.Lb_Progress.Name = "Lb_Progress";
            this.Lb_Progress.Size = new System.Drawing.Size(59, 12);
            this.Lb_Progress.TabIndex = 20;
            this.Lb_Progress.Text = "当前进度:";
            // 
            // Lb_Slash
            // 
            this.Lb_Slash.AutoSize = true;
            this.Lb_Slash.Location = new System.Drawing.Point(160, 342);
            this.Lb_Slash.Name = "Lb_Slash";
            this.Lb_Slash.Size = new System.Drawing.Size(11, 12);
            this.Lb_Slash.TabIndex = 21;
            this.Lb_Slash.Text = "/";
            // 
            // Lb_Total
            // 
            this.Lb_Total.AutoSize = true;
            this.Lb_Total.Location = new System.Drawing.Point(172, 342);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Size = new System.Drawing.Size(11, 12);
            this.Lb_Total.TabIndex = 22;
            this.Lb_Total.Text = "0";
            // 
            // Lb_TotalTime
            // 
            this.Lb_TotalTime.AutoSize = true;
            this.Lb_TotalTime.Location = new System.Drawing.Point(223, 342);
            this.Lb_TotalTime.Name = "Lb_TotalTime";
            this.Lb_TotalTime.Size = new System.Drawing.Size(0, 12);
            this.Lb_TotalTime.TabIndex = 23;
            // 
            // Lb_LoopCount
            // 
            this.Lb_LoopCount.AutoSize = true;
            this.Lb_LoopCount.Location = new System.Drawing.Point(28, 121);
            this.Lb_LoopCount.Name = "Lb_LoopCount";
            this.Lb_LoopCount.Size = new System.Drawing.Size(83, 12);
            this.Lb_LoopCount.TabIndex = 24;
            this.Lb_LoopCount.Text = "一类遍历次数:";
            // 
            // Tb_TypeOneLoopCount
            // 
            this.Tb_TypeOneLoopCount.Location = new System.Drawing.Point(116, 118);
            this.Tb_TypeOneLoopCount.Name = "Tb_TypeOneLoopCount";
            this.Tb_TypeOneLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeOneLoopCount.TabIndex = 25;
            this.Tb_TypeOneLoopCount.Text = "200";
            // 
            // LB_LoopCountUnit
            // 
            this.LB_LoopCountUnit.AutoSize = true;
            this.LB_LoopCountUnit.Location = new System.Drawing.Point(194, 121);
            this.LB_LoopCountUnit.Name = "LB_LoopCountUnit";
            this.LB_LoopCountUnit.Size = new System.Drawing.Size(41, 12);
            this.LB_LoopCountUnit.TabIndex = 26;
            this.LB_LoopCountUnit.Text = "万(次)";
            // 
            // Btn_Debug
            // 
            this.Btn_Debug.Location = new System.Drawing.Point(59, 373);
            this.Btn_Debug.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Debug.Name = "Btn_Debug";
            this.Btn_Debug.Size = new System.Drawing.Size(68, 41);
            this.Btn_Debug.TabIndex = 27;
            this.Btn_Debug.Text = "调试";
            this.Btn_Debug.UseVisualStyleBackColor = true;
            this.Btn_Debug.Visible = false;
            this.Btn_Debug.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lb_DataType
            // 
            this.Lb_DataType.AutoSize = true;
            this.Lb_DataType.Location = new System.Drawing.Point(75, 271);
            this.Lb_DataType.Name = "Lb_DataType";
            this.Lb_DataType.Size = new System.Drawing.Size(35, 12);
            this.Lb_DataType.TabIndex = 28;
            this.Lb_DataType.Text = "数据:";
            // 
            // Cb_DataType
            // 
            this.Cb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_DataType.FormattingEnabled = true;
            this.Cb_DataType.Location = new System.Drawing.Point(116, 268);
            this.Cb_DataType.Name = "Cb_DataType";
            this.Cb_DataType.Size = new System.Drawing.Size(121, 20);
            this.Cb_DataType.TabIndex = 29;
            // 
            // Lb_TypeOneDeviation
            // 
            this.Lb_TypeOneDeviation.AutoSize = true;
            this.Lb_TypeOneDeviation.Location = new System.Drawing.Point(241, 121);
            this.Lb_TypeOneDeviation.Name = "Lb_TypeOneDeviation";
            this.Lb_TypeOneDeviation.Size = new System.Drawing.Size(47, 12);
            this.Lb_TypeOneDeviation.TabIndex = 30;
            this.Lb_TypeOneDeviation.Text = "修正值:";
            // 
            // Tb_TypeOneIncreaseNumber
            // 
            this.Tb_TypeOneIncreaseNumber.Location = new System.Drawing.Point(289, 118);
            this.Tb_TypeOneIncreaseNumber.Name = "Tb_TypeOneIncreaseNumber";
            this.Tb_TypeOneIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeOneIncreaseNumber.TabIndex = 31;
            this.Tb_TypeOneIncreaseNumber.Text = "0.00001";
            // 
            // Lb_TypeTwo
            // 
            this.Lb_TypeTwo.AutoSize = true;
            this.Lb_TypeTwo.Location = new System.Drawing.Point(27, 153);
            this.Lb_TypeTwo.Name = "Lb_TypeTwo";
            this.Lb_TypeTwo.Size = new System.Drawing.Size(83, 12);
            this.Lb_TypeTwo.TabIndex = 24;
            this.Lb_TypeTwo.Text = "二类遍历次数:";
            // 
            // Tb_TypeTwoLoopCount
            // 
            this.Tb_TypeTwoLoopCount.Location = new System.Drawing.Point(116, 150);
            this.Tb_TypeTwoLoopCount.Name = "Tb_TypeTwoLoopCount";
            this.Tb_TypeTwoLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeTwoLoopCount.TabIndex = 25;
            this.Tb_TypeTwoLoopCount.Text = "200";
            // 
            // Lb_TypeTwoLoopCountUnit
            // 
            this.Lb_TypeTwoLoopCountUnit.AutoSize = true;
            this.Lb_TypeTwoLoopCountUnit.Location = new System.Drawing.Point(194, 153);
            this.Lb_TypeTwoLoopCountUnit.Name = "Lb_TypeTwoLoopCountUnit";
            this.Lb_TypeTwoLoopCountUnit.Size = new System.Drawing.Size(41, 12);
            this.Lb_TypeTwoLoopCountUnit.TabIndex = 26;
            this.Lb_TypeTwoLoopCountUnit.Text = "万(次)";
            // 
            // Lb_TypeTwoDeviation
            // 
            this.Lb_TypeTwoDeviation.AutoSize = true;
            this.Lb_TypeTwoDeviation.Location = new System.Drawing.Point(241, 153);
            this.Lb_TypeTwoDeviation.Name = "Lb_TypeTwoDeviation";
            this.Lb_TypeTwoDeviation.Size = new System.Drawing.Size(47, 12);
            this.Lb_TypeTwoDeviation.TabIndex = 30;
            this.Lb_TypeTwoDeviation.Text = "修正值:";
            // 
            // Tb_TypeTwoIncreaseNumber
            // 
            this.Tb_TypeTwoIncreaseNumber.Location = new System.Drawing.Point(289, 150);
            this.Tb_TypeTwoIncreaseNumber.Name = "Tb_TypeTwoIncreaseNumber";
            this.Tb_TypeTwoIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeTwoIncreaseNumber.TabIndex = 31;
            this.Tb_TypeTwoIncreaseNumber.Text = "0.00001";
            // 
            // Lb_TypeThreeLoopCount
            // 
            this.Lb_TypeThreeLoopCount.AutoSize = true;
            this.Lb_TypeThreeLoopCount.Location = new System.Drawing.Point(28, 186);
            this.Lb_TypeThreeLoopCount.Name = "Lb_TypeThreeLoopCount";
            this.Lb_TypeThreeLoopCount.Size = new System.Drawing.Size(83, 12);
            this.Lb_TypeThreeLoopCount.TabIndex = 24;
            this.Lb_TypeThreeLoopCount.Text = "三类遍历次数:";
            // 
            // Tb_TypeThreeLoopCount
            // 
            this.Tb_TypeThreeLoopCount.Location = new System.Drawing.Point(116, 183);
            this.Tb_TypeThreeLoopCount.Name = "Tb_TypeThreeLoopCount";
            this.Tb_TypeThreeLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeThreeLoopCount.TabIndex = 25;
            this.Tb_TypeThreeLoopCount.Text = "200";
            // 
            // Lb_TypeThreeLoopCountUnit
            // 
            this.Lb_TypeThreeLoopCountUnit.AutoSize = true;
            this.Lb_TypeThreeLoopCountUnit.Location = new System.Drawing.Point(194, 186);
            this.Lb_TypeThreeLoopCountUnit.Name = "Lb_TypeThreeLoopCountUnit";
            this.Lb_TypeThreeLoopCountUnit.Size = new System.Drawing.Size(41, 12);
            this.Lb_TypeThreeLoopCountUnit.TabIndex = 26;
            this.Lb_TypeThreeLoopCountUnit.Text = "万(次)";
            // 
            // Lb_TypeThreeDeviation
            // 
            this.Lb_TypeThreeDeviation.AutoSize = true;
            this.Lb_TypeThreeDeviation.Location = new System.Drawing.Point(241, 186);
            this.Lb_TypeThreeDeviation.Name = "Lb_TypeThreeDeviation";
            this.Lb_TypeThreeDeviation.Size = new System.Drawing.Size(47, 12);
            this.Lb_TypeThreeDeviation.TabIndex = 30;
            this.Lb_TypeThreeDeviation.Text = "修正值:";
            // 
            // Tb_TypeThreeIncreaseNumber
            // 
            this.Tb_TypeThreeIncreaseNumber.Location = new System.Drawing.Point(289, 183);
            this.Tb_TypeThreeIncreaseNumber.Name = "Tb_TypeThreeIncreaseNumber";
            this.Tb_TypeThreeIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeThreeIncreaseNumber.TabIndex = 31;
            this.Tb_TypeThreeIncreaseNumber.Text = "0.00001";
            // 
            // Lb_ComputeType
            // 
            this.Lb_ComputeType.AutoSize = true;
            this.Lb_ComputeType.Location = new System.Drawing.Point(51, 27);
            this.Lb_ComputeType.Name = "Lb_ComputeType";
            this.Lb_ComputeType.Size = new System.Drawing.Size(59, 12);
            this.Lb_ComputeType.TabIndex = 32;
            this.Lb_ComputeType.Text = "计算方式:";
            // 
            // Rb_SingleFile
            // 
            this.Rb_SingleFile.AutoSize = true;
            this.Rb_SingleFile.Checked = true;
            this.Rb_SingleFile.Location = new System.Drawing.Point(6, 13);
            this.Rb_SingleFile.Name = "Rb_SingleFile";
            this.Rb_SingleFile.Size = new System.Drawing.Size(71, 16);
            this.Rb_SingleFile.TabIndex = 33;
            this.Rb_SingleFile.TabStop = true;
            this.Rb_SingleFile.Text = "单个文件";
            this.Rb_SingleFile.UseVisualStyleBackColor = true;
            this.Rb_SingleFile.CheckedChanged += new System.EventHandler(this.Rb_SingleFile_CheckedChanged);
            // 
            // Rb_MulitpleFiles
            // 
            this.Rb_MulitpleFiles.AutoSize = true;
            this.Rb_MulitpleFiles.Location = new System.Drawing.Point(134, 13);
            this.Rb_MulitpleFiles.Name = "Rb_MulitpleFiles";
            this.Rb_MulitpleFiles.Size = new System.Drawing.Size(47, 16);
            this.Rb_MulitpleFiles.TabIndex = 34;
            this.Rb_MulitpleFiles.Text = "批量";
            this.Rb_MulitpleFiles.UseVisualStyleBackColor = true;
            this.Rb_MulitpleFiles.CheckedChanged += new System.EventHandler(this.Rb_MulitpleFiles_CheckedChanged);
            // 
            // Gb_FileType
            // 
            this.Gb_FileType.Controls.Add(this.Rb_MulitpleFiles);
            this.Gb_FileType.Controls.Add(this.Rb_SingleFile);
            this.Gb_FileType.Location = new System.Drawing.Point(116, 12);
            this.Gb_FileType.Name = "Gb_FileType";
            this.Gb_FileType.Size = new System.Drawing.Size(279, 35);
            this.Gb_FileType.TabIndex = 35;
            this.Gb_FileType.TabStop = false;
            // 
            // Gb_RandomType
            // 
            this.Gb_RandomType.Controls.Add(this.Rb_RandomPerRecord);
            this.Gb_RandomType.Controls.Add(this.Rb_SameRandom);
            this.Gb_RandomType.Location = new System.Drawing.Point(116, 212);
            this.Gb_RandomType.Name = "Gb_RandomType";
            this.Gb_RandomType.Size = new System.Drawing.Size(276, 38);
            this.Gb_RandomType.TabIndex = 36;
            this.Gb_RandomType.TabStop = false;
            // 
            // Lb_ResultSaveType
            // 
            this.Lb_ResultSaveType.AutoSize = true;
            this.Lb_ResultSaveType.Location = new System.Drawing.Point(27, 304);
            this.Lb_ResultSaveType.Name = "Lb_ResultSaveType";
            this.Lb_ResultSaveType.Size = new System.Drawing.Size(83, 12);
            this.Lb_ResultSaveType.TabIndex = 37;
            this.Lb_ResultSaveType.Text = "结果保存方式:";
            // 
            // Cb_ResultSaveType
            // 
            this.Cb_ResultSaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_ResultSaveType.FormattingEnabled = true;
            this.Cb_ResultSaveType.Location = new System.Drawing.Point(117, 304);
            this.Cb_ResultSaveType.Name = "Cb_ResultSaveType";
            this.Cb_ResultSaveType.Size = new System.Drawing.Size(118, 20);
            this.Cb_ResultSaveType.TabIndex = 38;
            // 
            // Lb_TValue
            // 
            this.Lb_TValue.AutoSize = true;
            this.Lb_TValue.Location = new System.Drawing.Point(235, 92);
            this.Lb_TValue.Name = "Lb_TValue";
            this.Lb_TValue.Size = new System.Drawing.Size(53, 12);
            this.Lb_TValue.TabIndex = 39;
            this.Lb_TValue.Text = "T最小值:";
            // 
            // Tb_TValue
            // 
            this.Tb_TValue.Location = new System.Drawing.Point(289, 89);
            this.Tb_TValue.Name = "Tb_TValue";
            this.Tb_TValue.Size = new System.Drawing.Size(74, 21);
            this.Tb_TValue.TabIndex = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 423);
            this.Controls.Add(this.Tb_TValue);
            this.Controls.Add(this.Lb_TValue);
            this.Controls.Add(this.Cb_ResultSaveType);
            this.Controls.Add(this.Lb_ResultSaveType);
            this.Controls.Add(this.Gb_RandomType);
            this.Controls.Add(this.Gb_FileType);
            this.Controls.Add(this.Lb_ComputeType);
            this.Controls.Add(this.Tb_TypeThreeIncreaseNumber);
            this.Controls.Add(this.Lb_TypeThreeDeviation);
            this.Controls.Add(this.Tb_TypeTwoIncreaseNumber);
            this.Controls.Add(this.Lb_TypeTwoDeviation);
            this.Controls.Add(this.Tb_TypeOneIncreaseNumber);
            this.Controls.Add(this.Lb_TypeOneDeviation);
            this.Controls.Add(this.Cb_DataType);
            this.Controls.Add(this.Lb_TypeThreeLoopCountUnit);
            this.Controls.Add(this.Lb_DataType);
            this.Controls.Add(this.Lb_TypeTwoLoopCountUnit);
            this.Controls.Add(this.Tb_TypeThreeLoopCount);
            this.Controls.Add(this.Btn_Debug);
            this.Controls.Add(this.Tb_TypeTwoLoopCount);
            this.Controls.Add(this.Lb_TypeThreeLoopCount);
            this.Controls.Add(this.LB_LoopCountUnit);
            this.Controls.Add(this.Lb_TypeTwo);
            this.Controls.Add(this.Tb_TypeOneLoopCount);
            this.Controls.Add(this.Lb_LoopCount);
            this.Controls.Add(this.Lb_TotalTime);
            this.Controls.Add(this.Lb_Total);
            this.Controls.Add(this.Lb_Slash);
            this.Controls.Add(this.Lb_Progress);
            this.Controls.Add(this.Lb_Finished);
            this.Controls.Add(this.LB_RandomWay);
            this.Controls.Add(this.Lb_DefaultValue);
            this.Controls.Add(this.Btn_Calcualte);
            this.Controls.Add(this.Tb_Ph2MinusPv);
            this.Controls.Add(this.Btn_OpenFile);
            this.Controls.Add(this.Tb_SourceDataPath);
            this.Controls.Add(this.LB_DataSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据计算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Gb_FileType.ResumeLayout(false);
            this.Gb_FileType.PerformLayout();
            this.Gb_RandomType.ResumeLayout(false);
            this.Gb_RandomType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_DataSource;
        private System.Windows.Forms.TextBox Tb_SourceDataPath;
        private System.Windows.Forms.Button Btn_OpenFile;
        private System.Windows.Forms.TextBox Tb_Ph2MinusPv;
        private System.Windows.Forms.Button Btn_Calcualte;
        private System.Windows.Forms.Label Lb_DefaultValue;
        private System.Windows.Forms.Label LB_RandomWay;
        private System.Windows.Forms.RadioButton Rb_RandomPerRecord;
        private System.Windows.Forms.RadioButton Rb_SameRandom;
        private System.Windows.Forms.Label Lb_Finished;
        private System.Windows.Forms.Label Lb_Progress;
        private System.Windows.Forms.Label Lb_Slash;
        private System.Windows.Forms.Label Lb_Total;
        private System.Windows.Forms.Label Lb_TotalTime;
        private System.Windows.Forms.Label Lb_LoopCount;
        private System.Windows.Forms.TextBox Tb_TypeOneLoopCount;
        private System.Windows.Forms.Label LB_LoopCountUnit;
        private System.Windows.Forms.Button Btn_Debug;
        private System.Windows.Forms.Label Lb_DataType;
        private System.Windows.Forms.ComboBox Cb_DataType;
        private System.Windows.Forms.Label Lb_TypeOneDeviation;
        private System.Windows.Forms.TextBox Tb_TypeOneIncreaseNumber;
        private System.Windows.Forms.Label Lb_TypeTwo;
        private System.Windows.Forms.TextBox Tb_TypeTwoLoopCount;
        private System.Windows.Forms.Label Lb_TypeTwoLoopCountUnit;
        private System.Windows.Forms.Label Lb_TypeTwoDeviation;
        private System.Windows.Forms.TextBox Tb_TypeTwoIncreaseNumber;
        private System.Windows.Forms.Label Lb_TypeThreeLoopCount;
        private System.Windows.Forms.TextBox Tb_TypeThreeLoopCount;
        private System.Windows.Forms.Label Lb_TypeThreeLoopCountUnit;
        private System.Windows.Forms.Label Lb_TypeThreeDeviation;
        private System.Windows.Forms.TextBox Tb_TypeThreeIncreaseNumber;
        private System.Windows.Forms.Label Lb_ComputeType;
        private System.Windows.Forms.RadioButton Rb_SingleFile;
        private System.Windows.Forms.RadioButton Rb_MulitpleFiles;
        private System.Windows.Forms.GroupBox Gb_FileType;
        private System.Windows.Forms.GroupBox Gb_RandomType;
        private System.Windows.Forms.Label Lb_ResultSaveType;
        private System.Windows.Forms.ComboBox Cb_ResultSaveType;
        private System.Windows.Forms.Label Lb_TValue;
        private System.Windows.Forms.TextBox Tb_TValue;
    }
}

