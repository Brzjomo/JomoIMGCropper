namespace JomoIMGCropper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BTN_Crop = new Button();
            LB_Input = new Label();
            LB_Output = new Label();
            LLB_Input = new LinkLabel();
            LLB_Output = new LinkLabel();
            BTN_SelectInput = new Button();
            BTN_SelectOutput = new Button();
            CB_SetOutputDirectory = new CheckBox();
            groupBox1 = new GroupBox();
            TB_MaxSizeLimit = new TextBox();
            CB_MaxSizeLimit = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            PB_Download = new ProgressBar();
            BTN_Download = new Button();
            groupBox2 = new GroupBox();
            LB_MaxThreads = new Label();
            NUD_MaxThreads = new NumericUpDown();
            BTN_SelectSavePath = new Button();
            LB_SavePath = new Label();
            LLB_SavePath = new LinkLabel();
            LB_LinksFile = new Label();
            BTN_SelectLinksFile = new Button();
            LLB_LinksFile = new LinkLabel();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_MaxThreads).BeginInit();
            SuspendLayout();
            // 
            // BTN_Crop
            // 
            BTN_Crop.Location = new Point(290, 281);
            BTN_Crop.Name = "BTN_Crop";
            BTN_Crop.Size = new Size(118, 53);
            BTN_Crop.TabIndex = 0;
            BTN_Crop.Text = "裁剪";
            BTN_Crop.UseVisualStyleBackColor = true;
            BTN_Crop.Click += BTN_Crop_Click;
            // 
            // LB_Input
            // 
            LB_Input.AutoSize = true;
            LB_Input.Location = new Point(26, 28);
            LB_Input.Name = "LB_Input";
            LB_Input.Size = new Size(94, 21);
            LB_Input.TabIndex = 1;
            LB_Input.Text = "图片文件夹:";
            // 
            // LB_Output
            // 
            LB_Output.AutoSize = true;
            LB_Output.Location = new Point(26, 71);
            LB_Output.Name = "LB_Output";
            LB_Output.Size = new Size(94, 21);
            LB_Output.TabIndex = 2;
            LB_Output.Text = "输出文件夹:";
            // 
            // LLB_Input
            // 
            LLB_Input.LinkColor = Color.FromArgb(255, 128, 0);
            LLB_Input.Location = new Point(126, 28);
            LLB_Input.Name = "LLB_Input";
            LLB_Input.Size = new Size(188, 21);
            LLB_Input.TabIndex = 3;
            LLB_Input.TabStop = true;
            LLB_Input.Text = "未选择";
            LLB_Input.LinkClicked += LLB_Input_LinkClicked;
            // 
            // LLB_Output
            // 
            LLB_Output.LinkColor = Color.FromArgb(255, 128, 0);
            LLB_Output.Location = new Point(126, 71);
            LLB_Output.Name = "LLB_Output";
            LLB_Output.Size = new Size(188, 21);
            LLB_Output.TabIndex = 4;
            LLB_Output.TabStop = true;
            LLB_Output.Text = "未选择";
            LLB_Output.LinkClicked += LLB_Output_LinkClicked;
            // 
            // BTN_SelectInput
            // 
            BTN_SelectInput.Location = new Point(320, 20);
            BTN_SelectInput.Name = "BTN_SelectInput";
            BTN_SelectInput.Size = new Size(88, 37);
            BTN_SelectInput.TabIndex = 5;
            BTN_SelectInput.Text = "选择";
            BTN_SelectInput.UseVisualStyleBackColor = true;
            BTN_SelectInput.Click += BTN_SelectInput_Click;
            // 
            // BTN_SelectOutput
            // 
            BTN_SelectOutput.Location = new Point(320, 63);
            BTN_SelectOutput.Name = "BTN_SelectOutput";
            BTN_SelectOutput.Size = new Size(88, 37);
            BTN_SelectOutput.TabIndex = 6;
            BTN_SelectOutput.Text = "选择";
            BTN_SelectOutput.UseVisualStyleBackColor = true;
            BTN_SelectOutput.Click += BTN_SelectOutput_Click;
            // 
            // CB_SetOutputDirectory
            // 
            CB_SetOutputDirectory.AutoSize = true;
            CB_SetOutputDirectory.Location = new Point(20, 27);
            CB_SetOutputDirectory.Name = "CB_SetOutputDirectory";
            CB_SetOutputDirectory.Size = new Size(173, 25);
            CB_SetOutputDirectory.TabIndex = 7;
            CB_SetOutputDirectory.Text = "单独设置输出文件夹";
            CB_SetOutputDirectory.UseVisualStyleBackColor = true;
            CB_SetOutputDirectory.CheckedChanged += CB_SetOutputDirectory_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TB_MaxSizeLimit);
            groupBox1.Controls.Add(CB_MaxSizeLimit);
            groupBox1.Controls.Add(CB_SetOutputDirectory);
            groupBox1.Location = new Point(26, 126);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 141);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "设置";
            // 
            // TB_MaxSizeLimit
            // 
            TB_MaxSizeLimit.Location = new Point(153, 57);
            TB_MaxSizeLimit.Name = "TB_MaxSizeLimit";
            TB_MaxSizeLimit.Size = new Size(64, 28);
            TB_MaxSizeLimit.TabIndex = 9;
            TB_MaxSizeLimit.Text = "512";
            TB_MaxSizeLimit.TextAlign = HorizontalAlignment.Center;
            // 
            // CB_MaxSizeLimit
            // 
            CB_MaxSizeLimit.AutoSize = true;
            CB_MaxSizeLimit.Location = new Point(20, 58);
            CB_MaxSizeLimit.Name = "CB_MaxSizeLimit";
            CB_MaxSizeLimit.Size = new Size(129, 25);
            CB_MaxSizeLimit.TabIndex = 8;
            CB_MaxSizeLimit.Text = "限制最大尺寸:";
            CB_MaxSizeLimit.UseVisualStyleBackColor = true;
            CB_MaxSizeLimit.CheckedChanged += CB_MaxSizeLimit_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(441, 390);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(LB_Input);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(BTN_Crop);
            tabPage1.Controls.Add(BTN_SelectOutput);
            tabPage1.Controls.Add(LB_Output);
            tabPage1.Controls.Add(BTN_SelectInput);
            tabPage1.Controls.Add(LLB_Input);
            tabPage1.Controls.Add(LLB_Output);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(433, 356);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "裁剪";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(PB_Download);
            tabPage2.Controls.Add(BTN_Download);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(BTN_SelectSavePath);
            tabPage2.Controls.Add(LB_SavePath);
            tabPage2.Controls.Add(LLB_SavePath);
            tabPage2.Controls.Add(LB_LinksFile);
            tabPage2.Controls.Add(BTN_SelectLinksFile);
            tabPage2.Controls.Add(LLB_LinksFile);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(433, 356);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "下载";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // PB_Download
            // 
            PB_Download.Location = new Point(26, 296);
            PB_Download.Name = "PB_Download";
            PB_Download.Size = new Size(248, 23);
            PB_Download.TabIndex = 9;
            // 
            // BTN_Download
            // 
            BTN_Download.Location = new Point(290, 281);
            BTN_Download.Name = "BTN_Download";
            BTN_Download.Size = new Size(118, 53);
            BTN_Download.TabIndex = 15;
            BTN_Download.Text = "下载";
            BTN_Download.UseVisualStyleBackColor = true;
            BTN_Download.Click += BTN_Download_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LB_MaxThreads);
            groupBox2.Controls.Add(NUD_MaxThreads);
            groupBox2.Location = new Point(26, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(382, 141);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "设置";
            // 
            // LB_MaxThreads
            // 
            LB_MaxThreads.AutoSize = true;
            LB_MaxThreads.Location = new Point(20, 27);
            LB_MaxThreads.Name = "LB_MaxThreads";
            LB_MaxThreads.Size = new Size(94, 21);
            LB_MaxThreads.TabIndex = 9;
            LB_MaxThreads.Text = "最大线程数:";
            // 
            // NUD_MaxThreads
            // 
            NUD_MaxThreads.Location = new Point(120, 24);
            NUD_MaxThreads.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            NUD_MaxThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MaxThreads.Name = "NUD_MaxThreads";
            NUD_MaxThreads.Size = new Size(65, 28);
            NUD_MaxThreads.TabIndex = 10;
            NUD_MaxThreads.TextAlign = HorizontalAlignment.Center;
            NUD_MaxThreads.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // BTN_SelectSavePath
            // 
            BTN_SelectSavePath.Location = new Point(320, 63);
            BTN_SelectSavePath.Name = "BTN_SelectSavePath";
            BTN_SelectSavePath.Size = new Size(88, 37);
            BTN_SelectSavePath.TabIndex = 13;
            BTN_SelectSavePath.Text = "选择";
            BTN_SelectSavePath.UseVisualStyleBackColor = true;
            BTN_SelectSavePath.Click += BTN_SelectSavePath_Click;
            // 
            // LB_SavePath
            // 
            LB_SavePath.AutoSize = true;
            LB_SavePath.Location = new Point(26, 71);
            LB_SavePath.Name = "LB_SavePath";
            LB_SavePath.Size = new Size(94, 21);
            LB_SavePath.TabIndex = 11;
            LB_SavePath.Text = "保存文件夹:";
            // 
            // LLB_SavePath
            // 
            LLB_SavePath.LinkColor = Color.FromArgb(255, 128, 0);
            LLB_SavePath.Location = new Point(126, 71);
            LLB_SavePath.Name = "LLB_SavePath";
            LLB_SavePath.Size = new Size(188, 21);
            LLB_SavePath.TabIndex = 12;
            LLB_SavePath.TabStop = true;
            LLB_SavePath.Text = "未选择";
            LLB_SavePath.LinkClicked += LLB_SavePath_LinkClicked;
            // 
            // LB_LinksFile
            // 
            LB_LinksFile.AutoSize = true;
            LB_LinksFile.Location = new Point(26, 28);
            LB_LinksFile.Name = "LB_LinksFile";
            LB_LinksFile.Size = new Size(78, 21);
            LB_LinksFile.TabIndex = 6;
            LB_LinksFile.Text = "链接地址:";
            // 
            // BTN_SelectLinksFile
            // 
            BTN_SelectLinksFile.Location = new Point(320, 20);
            BTN_SelectLinksFile.Name = "BTN_SelectLinksFile";
            BTN_SelectLinksFile.Size = new Size(88, 37);
            BTN_SelectLinksFile.TabIndex = 8;
            BTN_SelectLinksFile.Text = "选择";
            BTN_SelectLinksFile.UseVisualStyleBackColor = true;
            BTN_SelectLinksFile.Click += BTN_SelectLinksFile_Click;
            // 
            // LLB_LinksFile
            // 
            LLB_LinksFile.LinkColor = Color.FromArgb(255, 128, 0);
            LLB_LinksFile.Location = new Point(126, 28);
            LLB_LinksFile.Name = "LLB_LinksFile";
            LLB_LinksFile.Size = new Size(188, 21);
            LLB_LinksFile.TabIndex = 7;
            LLB_LinksFile.TabStop = true;
            LLB_LinksFile.Text = "未选择";
            LLB_LinksFile.LinkClicked += LLB_LinksFile_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 413);
            Controls.Add(tabControl1);
            Font = new Font("Microsoft YaHei UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Jomo图片裁剪器";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_MaxThreads).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Crop;
        private Label LB_Input;
        private Label LB_Output;
        private LinkLabel LLB_Input;
        private LinkLabel LLB_Output;
        private Button BTN_SelectInput;
        private Button BTN_SelectOutput;
        private CheckBox CB_SetOutputDirectory;
        private GroupBox groupBox1;
        private TextBox TB_MaxSizeLimit;
        private CheckBox CB_MaxSizeLimit;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label LB_LinksFile;
        private Button BTN_SelectLinksFile;
        private LinkLabel LLB_LinksFile;
        private Label LB_MaxThreads;
        private NumericUpDown NUD_MaxThreads;
        private Button BTN_SelectSavePath;
        private Label LB_SavePath;
        private LinkLabel LLB_SavePath;
        private GroupBox groupBox2;
        private Button BTN_Download;
        private ProgressBar PB_Download;
    }
}
