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
            this.label1 = new System.Windows.Forms.Label();
            this.Lb_Total = new System.Windows.Forms.Label();
            this.Lb_TotalTime = new System.Windows.Forms.Label();
            this.Lb_LoopCount = new System.Windows.Forms.Label();
            this.Tb_LoopCount = new System.Windows.Forms.TextBox();
            this.LB_LoopCountUnit = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Lb_DataType = new System.Windows.Forms.Label();
            this.Cb_DataType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LB_DataSource
            // 
            this.LB_DataSource.AutoSize = true;
            this.LB_DataSource.Location = new System.Drawing.Point(52, 30);
            this.LB_DataSource.Name = "LB_DataSource";
            this.LB_DataSource.Size = new System.Drawing.Size(59, 12);
            this.LB_DataSource.TabIndex = 0;
            this.LB_DataSource.Text = "原始数据:";
            // 
            // Tb_SourceDataPath
            // 
            this.Tb_SourceDataPath.Location = new System.Drawing.Point(117, 27);
            this.Tb_SourceDataPath.Name = "Tb_SourceDataPath";
            this.Tb_SourceDataPath.Size = new System.Drawing.Size(246, 21);
            this.Tb_SourceDataPath.TabIndex = 1;
            // 
            // Btn_OpenFile
            // 
            this.Btn_OpenFile.Location = new System.Drawing.Point(369, 27);
            this.Btn_OpenFile.Name = "Btn_OpenFile";
            this.Btn_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenFile.TabIndex = 2;
            this.Btn_OpenFile.Text = "选择文件";
            this.Btn_OpenFile.UseVisualStyleBackColor = true;
            this.Btn_OpenFile.Click += new System.EventHandler(this.Btn_OpenFile_Click);
            // 
            // Tb_Ph2MinusPv
            // 
            this.Tb_Ph2MinusPv.Location = new System.Drawing.Point(116, 63);
            this.Tb_Ph2MinusPv.Name = "Tb_Ph2MinusPv";
            this.Tb_Ph2MinusPv.Size = new System.Drawing.Size(57, 21);
            this.Tb_Ph2MinusPv.TabIndex = 11;
            this.Tb_Ph2MinusPv.Text = "2";
            // 
            // Btn_Calcualte
            // 
            this.Btn_Calcualte.Location = new System.Drawing.Point(355, 189);
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
            this.Lb_DefaultValue.Location = new System.Drawing.Point(51, 66);
            this.Lb_DefaultValue.Name = "Lb_DefaultValue";
            this.Lb_DefaultValue.Size = new System.Drawing.Size(59, 12);
            this.Lb_DefaultValue.TabIndex = 15;
            this.Lb_DefaultValue.Text = "默认差值:";
            // 
            // LB_RandomWay
            // 
            this.LB_RandomWay.AutoSize = true;
            this.LB_RandomWay.Location = new System.Drawing.Point(39, 100);
            this.LB_RandomWay.Name = "LB_RandomWay";
            this.LB_RandomWay.Size = new System.Drawing.Size(71, 12);
            this.LB_RandomWay.TabIndex = 16;
            this.LB_RandomWay.Text = "随机数规则:";
            // 
            // Rb_RandomPerRecord
            // 
            this.Rb_RandomPerRecord.AutoSize = true;
            this.Rb_RandomPerRecord.Location = new System.Drawing.Point(279, 100);
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
            this.Rb_SameRandom.Location = new System.Drawing.Point(116, 100);
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
            this.Lb_Finished.Location = new System.Drawing.Point(118, 160);
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
            this.Lb_Progress.Location = new System.Drawing.Point(51, 160);
            this.Lb_Progress.Name = "Lb_Progress";
            this.Lb_Progress.Size = new System.Drawing.Size(59, 12);
            this.Lb_Progress.TabIndex = 20;
            this.Lb_Progress.Text = "当前进度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "/";
            // 
            // Lb_Total
            // 
            this.Lb_Total.AutoSize = true;
            this.Lb_Total.Location = new System.Drawing.Point(172, 160);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Size = new System.Drawing.Size(11, 12);
            this.Lb_Total.TabIndex = 22;
            this.Lb_Total.Text = "0";
            // 
            // Lb_TotalTime
            // 
            this.Lb_TotalTime.AutoSize = true;
            this.Lb_TotalTime.Location = new System.Drawing.Point(223, 160);
            this.Lb_TotalTime.Name = "Lb_TotalTime";
            this.Lb_TotalTime.Size = new System.Drawing.Size(0, 12);
            this.Lb_TotalTime.TabIndex = 23;
            // 
            // Lb_LoopCount
            // 
            this.Lb_LoopCount.AutoSize = true;
            this.Lb_LoopCount.Location = new System.Drawing.Point(184, 66);
            this.Lb_LoopCount.Name = "Lb_LoopCount";
            this.Lb_LoopCount.Size = new System.Drawing.Size(59, 12);
            this.Lb_LoopCount.TabIndex = 24;
            this.Lb_LoopCount.Text = "遍历次数:";
            // 
            // Tb_LoopCount
            // 
            this.Tb_LoopCount.Location = new System.Drawing.Point(243, 63);
            this.Tb_LoopCount.Name = "Tb_LoopCount";
            this.Tb_LoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_LoopCount.TabIndex = 25;
            this.Tb_LoopCount.Text = "2000";
            // 
            // LB_LoopCountUnit
            // 
            this.LB_LoopCountUnit.AutoSize = true;
            this.LB_LoopCountUnit.Location = new System.Drawing.Point(321, 66);
            this.LB_LoopCountUnit.Name = "LB_LoopCountUnit";
            this.LB_LoopCountUnit.Size = new System.Drawing.Size(41, 12);
            this.LB_LoopCountUnit.TabIndex = 26;
            this.LB_LoopCountUnit.Text = "万(次)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 189);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 41);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lb_DataType
            // 
            this.Lb_DataType.AutoSize = true;
            this.Lb_DataType.Location = new System.Drawing.Point(69, 131);
            this.Lb_DataType.Name = "Lb_DataType";
            this.Lb_DataType.Size = new System.Drawing.Size(35, 12);
            this.Lb_DataType.TabIndex = 28;
            this.Lb_DataType.Text = "数据:";
            // 
            // Cb_DataType
            // 
            this.Cb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_DataType.FormattingEnabled = true;
            this.Cb_DataType.Location = new System.Drawing.Point(116, 128);
            this.Cb_DataType.Name = "Cb_DataType";
            this.Cb_DataType.Size = new System.Drawing.Size(121, 20);
            this.Cb_DataType.TabIndex = 29;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 240);
            this.Controls.Add(this.Cb_DataType);
            this.Controls.Add(this.Lb_DataType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LB_LoopCountUnit);
            this.Controls.Add(this.Tb_LoopCount);
            this.Controls.Add(this.Lb_LoopCount);
            this.Controls.Add(this.Lb_TotalTime);
            this.Controls.Add(this.Lb_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_Progress);
            this.Controls.Add(this.Lb_Finished);
            this.Controls.Add(this.Rb_SameRandom);
            this.Controls.Add(this.Rb_RandomPerRecord);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lb_Total;
        private System.Windows.Forms.Label Lb_TotalTime;
        private System.Windows.Forms.Label Lb_LoopCount;
        private System.Windows.Forms.TextBox Tb_LoopCount;
        private System.Windows.Forms.Label LB_LoopCountUnit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Lb_DataType;
        private System.Windows.Forms.ComboBox Cb_DataType;
    }
}

