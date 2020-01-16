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
            this.Tb_TypeOneLoopCount = new System.Windows.Forms.TextBox();
            this.LB_LoopCountUnit = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Lb_DataType = new System.Windows.Forms.Label();
            this.Cb_DataType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tb_TypeOneIncreaseNumber = new System.Windows.Forms.TextBox();
            this.Lb_TypeTwo = new System.Windows.Forms.Label();
            this.Tb_TypeTwoLoopCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Tb_TypeTwoIncreaseNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tb_TypeThreeLoopCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Tb_TypeThreeIncreaseNumber = new System.Windows.Forms.TextBox();
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
            this.Btn_Calcualte.Location = new System.Drawing.Point(356, 275);
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
            this.LB_RandomWay.Location = new System.Drawing.Point(39, 187);
            this.LB_RandomWay.Name = "LB_RandomWay";
            this.LB_RandomWay.Size = new System.Drawing.Size(71, 12);
            this.LB_RandomWay.TabIndex = 16;
            this.LB_RandomWay.Text = "随机数规则:";
            // 
            // Rb_RandomPerRecord
            // 
            this.Rb_RandomPerRecord.AutoSize = true;
            this.Rb_RandomPerRecord.Location = new System.Drawing.Point(279, 187);
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
            this.Rb_SameRandom.Location = new System.Drawing.Point(116, 187);
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
            this.Lb_Finished.Location = new System.Drawing.Point(118, 247);
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
            this.Lb_Progress.Location = new System.Drawing.Point(51, 247);
            this.Lb_Progress.Name = "Lb_Progress";
            this.Lb_Progress.Size = new System.Drawing.Size(59, 12);
            this.Lb_Progress.TabIndex = 20;
            this.Lb_Progress.Text = "当前进度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "/";
            // 
            // Lb_Total
            // 
            this.Lb_Total.AutoSize = true;
            this.Lb_Total.Location = new System.Drawing.Point(172, 247);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Size = new System.Drawing.Size(11, 12);
            this.Lb_Total.TabIndex = 22;
            this.Lb_Total.Text = "0";
            // 
            // Lb_TotalTime
            // 
            this.Lb_TotalTime.AutoSize = true;
            this.Lb_TotalTime.Location = new System.Drawing.Point(223, 247);
            this.Lb_TotalTime.Name = "Lb_TotalTime";
            this.Lb_TotalTime.Size = new System.Drawing.Size(0, 12);
            this.Lb_TotalTime.TabIndex = 23;
            // 
            // Lb_LoopCount
            // 
            this.Lb_LoopCount.AutoSize = true;
            this.Lb_LoopCount.Location = new System.Drawing.Point(28, 95);
            this.Lb_LoopCount.Name = "Lb_LoopCount";
            this.Lb_LoopCount.Size = new System.Drawing.Size(83, 12);
            this.Lb_LoopCount.TabIndex = 24;
            this.Lb_LoopCount.Text = "一类遍历次数:";
            // 
            // Tb_TypeOneLoopCount
            // 
            this.Tb_TypeOneLoopCount.Location = new System.Drawing.Point(116, 92);
            this.Tb_TypeOneLoopCount.Name = "Tb_TypeOneLoopCount";
            this.Tb_TypeOneLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeOneLoopCount.TabIndex = 25;
            this.Tb_TypeOneLoopCount.Text = "20";
            // 
            // LB_LoopCountUnit
            // 
            this.LB_LoopCountUnit.AutoSize = true;
            this.LB_LoopCountUnit.Location = new System.Drawing.Point(194, 95);
            this.LB_LoopCountUnit.Name = "LB_LoopCountUnit";
            this.LB_LoopCountUnit.Size = new System.Drawing.Size(41, 12);
            this.LB_LoopCountUnit.TabIndex = 26;
            this.LB_LoopCountUnit.Text = "万(次)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 276);
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
            this.Lb_DataType.Location = new System.Drawing.Point(69, 218);
            this.Lb_DataType.Name = "Lb_DataType";
            this.Lb_DataType.Size = new System.Drawing.Size(35, 12);
            this.Lb_DataType.TabIndex = 28;
            this.Lb_DataType.Text = "数据:";
            // 
            // Cb_DataType
            // 
            this.Cb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_DataType.FormattingEnabled = true;
            this.Cb_DataType.Location = new System.Drawing.Point(116, 215);
            this.Cb_DataType.Name = "Cb_DataType";
            this.Cb_DataType.Size = new System.Drawing.Size(121, 20);
            this.Cb_DataType.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "修正值:";
            // 
            // Tb_TypeOneIncreaseNumber
            // 
            this.Tb_TypeOneIncreaseNumber.Location = new System.Drawing.Point(289, 92);
            this.Tb_TypeOneIncreaseNumber.Name = "Tb_TypeOneIncreaseNumber";
            this.Tb_TypeOneIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeOneIncreaseNumber.TabIndex = 31;
            this.Tb_TypeOneIncreaseNumber.Text = "0.00001";
            // 
            // Lb_TypeTwo
            // 
            this.Lb_TypeTwo.AutoSize = true;
            this.Lb_TypeTwo.Location = new System.Drawing.Point(28, 127);
            this.Lb_TypeTwo.Name = "Lb_TypeTwo";
            this.Lb_TypeTwo.Size = new System.Drawing.Size(71, 12);
            this.Lb_TypeTwo.TabIndex = 24;
            this.Lb_TypeTwo.Text = "二遍历次数:";
            // 
            // Tb_TypeTwoLoopCount
            // 
            this.Tb_TypeTwoLoopCount.Location = new System.Drawing.Point(116, 124);
            this.Tb_TypeTwoLoopCount.Name = "Tb_TypeTwoLoopCount";
            this.Tb_TypeTwoLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeTwoLoopCount.TabIndex = 25;
            this.Tb_TypeTwoLoopCount.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "万(次)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "修正值:";
            // 
            // Tb_TypeTwoIncreaseNumber
            // 
            this.Tb_TypeTwoIncreaseNumber.Location = new System.Drawing.Point(289, 124);
            this.Tb_TypeTwoIncreaseNumber.Name = "Tb_TypeTwoIncreaseNumber";
            this.Tb_TypeTwoIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeTwoIncreaseNumber.TabIndex = 31;
            this.Tb_TypeTwoIncreaseNumber.Text = "0.00001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "三类遍历次数:";
            // 
            // Tb_TypeThreeLoopCount
            // 
            this.Tb_TypeThreeLoopCount.Location = new System.Drawing.Point(116, 157);
            this.Tb_TypeThreeLoopCount.Name = "Tb_TypeThreeLoopCount";
            this.Tb_TypeThreeLoopCount.Size = new System.Drawing.Size(72, 21);
            this.Tb_TypeThreeLoopCount.TabIndex = 25;
            this.Tb_TypeThreeLoopCount.Text = "20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "万(次)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "修正值:";
            // 
            // Tb_TypeThreeIncreaseNumber
            // 
            this.Tb_TypeThreeIncreaseNumber.Location = new System.Drawing.Point(289, 157);
            this.Tb_TypeThreeIncreaseNumber.Name = "Tb_TypeThreeIncreaseNumber";
            this.Tb_TypeThreeIncreaseNumber.Size = new System.Drawing.Size(74, 21);
            this.Tb_TypeThreeIncreaseNumber.TabIndex = 31;
            this.Tb_TypeThreeIncreaseNumber.Text = "0.1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 328);
            this.Controls.Add(this.Tb_TypeThreeIncreaseNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tb_TypeTwoIncreaseNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tb_TypeOneIncreaseNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cb_DataType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Lb_DataType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tb_TypeThreeLoopCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tb_TypeTwoLoopCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LB_LoopCountUnit);
            this.Controls.Add(this.Lb_TypeTwo);
            this.Controls.Add(this.Tb_TypeOneLoopCount);
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
        private System.Windows.Forms.TextBox Tb_TypeOneLoopCount;
        private System.Windows.Forms.Label LB_LoopCountUnit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Lb_DataType;
        private System.Windows.Forms.ComboBox Cb_DataType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tb_TypeOneIncreaseNumber;
        private System.Windows.Forms.Label Lb_TypeTwo;
        private System.Windows.Forms.TextBox Tb_TypeTwoLoopCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tb_TypeTwoIncreaseNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tb_TypeThreeLoopCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tb_TypeThreeIncreaseNumber;
    }
}

