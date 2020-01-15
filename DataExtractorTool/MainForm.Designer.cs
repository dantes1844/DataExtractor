﻿namespace DataExtractorTool
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
            this.Lb_OrderRule = new System.Windows.Forms.Label();
            this.Cb_MaximumParameter = new System.Windows.Forms.ComboBox();
            this.Cb_MediumParameter = new System.Windows.Forms.ComboBox();
            this.Cb_MinimumParameter = new System.Windows.Forms.ComboBox();
            this.Lb_Ph1BiggerThan = new System.Windows.Forms.Label();
            this.Tb_Ph2MinusPv = new System.Windows.Forms.TextBox();
            this.Lb_Ph2BiggerThanPv = new System.Windows.Forms.Label();
            this.Btn_Calcualte = new System.Windows.Forms.Button();
            this.Lb_DefaultValue = new System.Windows.Forms.Label();
            this.LB_RandomWay = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Lb_Finished = new System.Windows.Forms.Label();
            this.Lb_Progress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lb_Total = new System.Windows.Forms.Label();
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
            // Lb_OrderRule
            // 
            this.Lb_OrderRule.AutoSize = true;
            this.Lb_OrderRule.Location = new System.Drawing.Point(52, 67);
            this.Lb_OrderRule.Name = "Lb_OrderRule";
            this.Lb_OrderRule.Size = new System.Drawing.Size(59, 12);
            this.Lb_OrderRule.TabIndex = 3;
            this.Lb_OrderRule.Text = "排序规则:";
            // 
            // Cb_MaximumParameter
            // 
            this.Cb_MaximumParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_MaximumParameter.FormattingEnabled = true;
            this.Cb_MaximumParameter.Items.AddRange(new object[] {
            "Ph1",
            "Ph2",
            "Pv"});
            this.Cb_MaximumParameter.Location = new System.Drawing.Point(117, 64);
            this.Cb_MaximumParameter.Name = "Cb_MaximumParameter";
            this.Cb_MaximumParameter.Size = new System.Drawing.Size(57, 20);
            this.Cb_MaximumParameter.TabIndex = 4;
            this.Cb_MaximumParameter.SelectedIndexChanged += new System.EventHandler(this.Cb_MaximumParameter_SelectedIndexChanged);
            // 
            // Cb_MediumParameter
            // 
            this.Cb_MediumParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_MediumParameter.FormattingEnabled = true;
            this.Cb_MediumParameter.Location = new System.Drawing.Point(207, 64);
            this.Cb_MediumParameter.Name = "Cb_MediumParameter";
            this.Cb_MediumParameter.Size = new System.Drawing.Size(55, 20);
            this.Cb_MediumParameter.TabIndex = 6;
            // 
            // Cb_MinimumParameter
            // 
            this.Cb_MinimumParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_MinimumParameter.FormattingEnabled = true;
            this.Cb_MinimumParameter.Location = new System.Drawing.Point(300, 64);
            this.Cb_MinimumParameter.Name = "Cb_MinimumParameter";
            this.Cb_MinimumParameter.Size = new System.Drawing.Size(63, 20);
            this.Cb_MinimumParameter.TabIndex = 9;
            // 
            // Lb_Ph1BiggerThan
            // 
            this.Lb_Ph1BiggerThan.AutoSize = true;
            this.Lb_Ph1BiggerThan.Location = new System.Drawing.Point(190, 67);
            this.Lb_Ph1BiggerThan.Name = "Lb_Ph1BiggerThan";
            this.Lb_Ph1BiggerThan.Size = new System.Drawing.Size(11, 12);
            this.Lb_Ph1BiggerThan.TabIndex = 5;
            this.Lb_Ph1BiggerThan.Text = ">";
            // 
            // Tb_Ph2MinusPv
            // 
            this.Tb_Ph2MinusPv.Location = new System.Drawing.Point(117, 99);
            this.Tb_Ph2MinusPv.Name = "Tb_Ph2MinusPv";
            this.Tb_Ph2MinusPv.Size = new System.Drawing.Size(246, 21);
            this.Tb_Ph2MinusPv.TabIndex = 11;
            this.Tb_Ph2MinusPv.Text = "2";
            // 
            // Lb_Ph2BiggerThanPv
            // 
            this.Lb_Ph2BiggerThanPv.AutoSize = true;
            this.Lb_Ph2BiggerThanPv.Location = new System.Drawing.Point(279, 67);
            this.Lb_Ph2BiggerThanPv.Name = "Lb_Ph2BiggerThanPv";
            this.Lb_Ph2BiggerThanPv.Size = new System.Drawing.Size(11, 12);
            this.Lb_Ph2BiggerThanPv.TabIndex = 12;
            this.Lb_Ph2BiggerThanPv.Text = ">";
            // 
            // Btn_Calcualte
            // 
            this.Btn_Calcualte.Location = new System.Drawing.Point(369, 186);
            this.Btn_Calcualte.Name = "Btn_Calcualte";
            this.Btn_Calcualte.Size = new System.Drawing.Size(75, 23);
            this.Btn_Calcualte.TabIndex = 14;
            this.Btn_Calcualte.Text = "计算";
            this.Btn_Calcualte.UseVisualStyleBackColor = true;
            this.Btn_Calcualte.Click += new System.EventHandler(this.Btn_Calcualte_Click);
            // 
            // Lb_DefaultValue
            // 
            this.Lb_DefaultValue.AutoSize = true;
            this.Lb_DefaultValue.Location = new System.Drawing.Point(52, 102);
            this.Lb_DefaultValue.Name = "Lb_DefaultValue";
            this.Lb_DefaultValue.Size = new System.Drawing.Size(59, 12);
            this.Lb_DefaultValue.TabIndex = 15;
            this.Lb_DefaultValue.Text = "默认差值:";
            // 
            // LB_RandomWay
            // 
            this.LB_RandomWay.AutoSize = true;
            this.LB_RandomWay.Location = new System.Drawing.Point(40, 137);
            this.LB_RandomWay.Name = "LB_RandomWay";
            this.LB_RandomWay.Size = new System.Drawing.Size(71, 12);
            this.LB_RandomWay.TabIndex = 16;
            this.LB_RandomWay.Text = "随机数规则:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(117, 137);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "按记录随机";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(244, 135);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 16);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "使用同一个随机数";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Lb_Finished
            // 
            this.Lb_Finished.AutoSize = true;
            this.Lb_Finished.Location = new System.Drawing.Point(119, 167);
            this.Lb_Finished.Name = "Lb_Finished";
            this.Lb_Finished.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lb_Finished.Size = new System.Drawing.Size(11, 12);
            this.Lb_Finished.TabIndex = 19;
            this.Lb_Finished.Text = "0";
            this.Lb_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_Progress
            // 
            this.Lb_Progress.AutoSize = true;
            this.Lb_Progress.Location = new System.Drawing.Point(52, 167);
            this.Lb_Progress.Name = "Lb_Progress";
            this.Lb_Progress.Size = new System.Drawing.Size(59, 12);
            this.Lb_Progress.TabIndex = 20;
            this.Lb_Progress.Text = "当前进度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "/";
            // 
            // Lb_Total
            // 
            this.Lb_Total.AutoSize = true;
            this.Lb_Total.Location = new System.Drawing.Point(165, 167);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Size = new System.Drawing.Size(11, 12);
            this.Lb_Total.TabIndex = 22;
            this.Lb_Total.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 221);
            this.Controls.Add(this.Lb_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_Progress);
            this.Controls.Add(this.Lb_Finished);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.LB_RandomWay);
            this.Controls.Add(this.Lb_DefaultValue);
            this.Controls.Add(this.Btn_Calcualte);
            this.Controls.Add(this.Lb_Ph2BiggerThanPv);
            this.Controls.Add(this.Tb_Ph2MinusPv);
            this.Controls.Add(this.Cb_MinimumParameter);
            this.Controls.Add(this.Cb_MediumParameter);
            this.Controls.Add(this.Lb_Ph1BiggerThan);
            this.Controls.Add(this.Cb_MaximumParameter);
            this.Controls.Add(this.Lb_OrderRule);
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
        private System.Windows.Forms.Label Lb_OrderRule;
        private System.Windows.Forms.ComboBox Cb_MaximumParameter;
        private System.Windows.Forms.ComboBox Cb_MediumParameter;
        private System.Windows.Forms.ComboBox Cb_MinimumParameter;
        private System.Windows.Forms.Label Lb_Ph1BiggerThan;
        private System.Windows.Forms.TextBox Tb_Ph2MinusPv;
        private System.Windows.Forms.Label Lb_Ph2BiggerThanPv;
        private System.Windows.Forms.Button Btn_Calcualte;
        private System.Windows.Forms.Label Lb_DefaultValue;
        private System.Windows.Forms.Label LB_RandomWay;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label Lb_Finished;
        private System.Windows.Forms.Label Lb_Progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lb_Total;
    }
}
