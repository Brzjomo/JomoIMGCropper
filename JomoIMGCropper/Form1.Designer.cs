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
            SuspendLayout();
            // 
            // BTN_Crop
            // 
            BTN_Crop.Location = new Point(197, 170);
            BTN_Crop.Name = "BTN_Crop";
            BTN_Crop.Size = new Size(118, 53);
            BTN_Crop.TabIndex = 0;
            BTN_Crop.Text = "裁剪";
            BTN_Crop.UseVisualStyleBackColor = true;
            BTN_Crop.Click += BTN_Crop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 345);
            Controls.Add(BTN_Crop);
            Font = new Font("Microsoft YaHei UI", 12F);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Crop;
    }
}
