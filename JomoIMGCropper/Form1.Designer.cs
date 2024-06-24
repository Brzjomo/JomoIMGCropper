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
            CB_MaxSizeLimit = new CheckBox();
            TB_MaxSizeLimit = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BTN_Crop
            // 
            BTN_Crop.Location = new Point(292, 277);
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
            LB_Input.Location = new Point(28, 24);
            LB_Input.Name = "LB_Input";
            LB_Input.Size = new Size(94, 21);
            LB_Input.TabIndex = 1;
            LB_Input.Text = "图片文件夹:";
            // 
            // LB_Output
            // 
            LB_Output.AutoSize = true;
            LB_Output.Location = new Point(28, 67);
            LB_Output.Name = "LB_Output";
            LB_Output.Size = new Size(94, 21);
            LB_Output.TabIndex = 2;
            LB_Output.Text = "输出文件夹:";
            // 
            // LLB_Input
            // 
            LLB_Input.LinkColor = Color.FromArgb(255, 128, 0);
            LLB_Input.Location = new Point(128, 24);
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
            LLB_Output.Location = new Point(128, 67);
            LLB_Output.Name = "LLB_Output";
            LLB_Output.Size = new Size(188, 21);
            LLB_Output.TabIndex = 4;
            LLB_Output.TabStop = true;
            LLB_Output.Text = "未选择";
            LLB_Output.LinkClicked += LLB_Output_LinkClicked;
            // 
            // BTN_SelectInput
            // 
            BTN_SelectInput.Location = new Point(322, 16);
            BTN_SelectInput.Name = "BTN_SelectInput";
            BTN_SelectInput.Size = new Size(88, 37);
            BTN_SelectInput.TabIndex = 5;
            BTN_SelectInput.Text = "选择";
            BTN_SelectInput.UseVisualStyleBackColor = true;
            BTN_SelectInput.Click += BTN_SelectInput_Click;
            // 
            // BTN_SelectOutput
            // 
            BTN_SelectOutput.Location = new Point(322, 59);
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
            groupBox1.Location = new Point(28, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 141);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "设置";
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
            // TB_MaxSizeLimit
            // 
            TB_MaxSizeLimit.Location = new Point(153, 57);
            TB_MaxSizeLimit.Name = "TB_MaxSizeLimit";
            TB_MaxSizeLimit.Size = new Size(64, 28);
            TB_MaxSizeLimit.TabIndex = 9;
            TB_MaxSizeLimit.Text = "512";
            TB_MaxSizeLimit.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 345);
            Controls.Add(groupBox1);
            Controls.Add(BTN_SelectOutput);
            Controls.Add(BTN_SelectInput);
            Controls.Add(LLB_Output);
            Controls.Add(LLB_Input);
            Controls.Add(LB_Output);
            Controls.Add(LB_Input);
            Controls.Add(BTN_Crop);
            Font = new Font("Microsoft YaHei UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Jomo图片裁剪器";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
