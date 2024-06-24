using FreeImageAPI;
using System.Drawing.Imaging;

namespace JomoIMGCropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CB_SetOutputDirectory.Checked = false;
            LLB_Output.Enabled = false;
            BTN_SelectOutput.Enabled = false;
            CB_MaxSizeLimit.Checked = true;
            TB_MaxSizeLimit.Enabled = true;
            TB_MaxSizeLimit.Text = "512";
        }

        private static string InputFolder = String.Empty;
        private static string OutputFolder = String.Empty;

        private void CropImages()
        {
            if (InputFolder == String.Empty || CB_SetOutputDirectory.Checked && OutputFolder == String.Empty)
            {
                MessageBox.Show("��δ�������������ļ���" + ",\n�������ú�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CB_SetOutputDirectory.Checked)
            {
                OutputFolder = InputFolder + "\\" + "ProcessedTrainSets";
            }

            int maxSize = 512; // ����Ȼ�߶�

            try {
                maxSize = Int16.Parse(TB_MaxSizeLimit.Text);
            } catch
            {
                MessageBox.Show("ͼƬ���ߴ����ô���" + ",\n�����Ƿ�Ϊ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resolution = 72; // �ֱ���

            if (!Directory.Exists(InputFolder))
            {
                Directory.CreateDirectory(InputFolder);
                MessageBox.Show("�������ļ���" + InputFolder + ",\n���ȼ���Ҫ�����ͼƬ������ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(OutputFolder))
            {
                Directory.CreateDirectory(OutputFolder);
            }

            string[] files = Directory.GetFiles(InputFolder);

            foreach (string file in files)
            {
                try
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open))
                    {
                        using (Image image = Image.FromStream(stream, false, false))
                        {
                            if (CB_MaxSizeLimit.Checked)
                            {
                                int newWidth, newHeight;

                                if (image.Width > image.Height)
                                {
                                    newWidth = maxSize;
                                    newHeight = (int)(((double)image.Height / image.Width) * maxSize);
                                }
                                else
                                {
                                    newHeight = maxSize;
                                    newWidth = (int)(((double)image.Width / image.Height) * maxSize);
                                }

                                Bitmap newImage = new Bitmap(maxSize, maxSize);
                                Graphics graphics = Graphics.FromImage(newImage);
                                graphics.FillRectangle(Brushes.White, 0, 0, maxSize, maxSize);
                                graphics.DrawImage(image, (maxSize - newWidth) / 2, (maxSize - newHeight) / 2, newWidth, newHeight);

                                string outputFilePath = Path.Combine(OutputFolder, Path.GetFileName(file));
                                string[] _ = outputFilePath.Split('.');
                                outputFilePath = _[0] + ".jpeg";
                                newImage.SetResolution(resolution, resolution);
                                newImage.Save(outputFilePath, ImageFormat.Jpeg);
                            } else
                            {
                                string outputFilePath = Path.Combine(OutputFolder, Path.GetFileName(file));
                                string[] _ = outputFilePath.Split('.');
                                outputFilePath = _[0] + ".jpeg";
                                Bitmap newImage = new Bitmap(image.Width, image.Height);
                                Graphics graphics = Graphics.FromImage(newImage);
                                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                                newImage.SetResolution(resolution, resolution);
                                newImage.Save(outputFilePath, ImageFormat.Jpeg);
                            }
                        }
                    }
                }
                catch
                {
                    // ���ڲ�֧�ֵ�ͼƬ��ʹ��FreeImage�⴦��
                    FIBITMAP bitmap = FreeImage.LoadEx(file);

                    if (CB_MaxSizeLimit.Checked)
                    {
                        if (!bitmap.IsNull)
                        {
                            int width = (int)FreeImage.GetWidth(bitmap);
                            int height = (int)FreeImage.GetHeight(bitmap);

                            double aspectRatio = (double)width / height;
                            int newWidth = width > height ? maxSize : (int)(maxSize * aspectRatio);
                            int newHeight = width > height ? (int)(maxSize / aspectRatio) : maxSize;

                            Bitmap newImage = new Bitmap(maxSize, maxSize);
                            Graphics graphics = Graphics.FromImage(newImage);
                            graphics.FillRectangle(Brushes.White, 0, 0, maxSize, maxSize);
                            Image image = FreeImage.GetBitmap(bitmap);
                            graphics.DrawImage(image, (maxSize - newWidth) / 2, (maxSize - newHeight) / 2, newWidth, newHeight);

                            string outputFilePath = Path.Combine(OutputFolder, Path.GetFileName(file));
                            string[] _ = outputFilePath.Split('.');
                            outputFilePath = _[0] + ".jpeg";
                            newImage.SetResolution(resolution, resolution);
                            newImage.Save(outputFilePath, ImageFormat.Jpeg);

                            FreeImage.Unload(bitmap);
                        }
                    } else
                    {
                        if (!bitmap.IsNull)
                        {
                            int width = (int)FreeImage.GetWidth(bitmap);
                            int height = (int)FreeImage.GetHeight(bitmap);

                            Bitmap newImage = new Bitmap(width, height);
                            Graphics graphics = Graphics.FromImage(newImage);
                            Image image = FreeImage.GetBitmap(bitmap);
                            graphics.DrawImage(image, 0, 0, width, height);

                            string outputFilePath = Path.Combine(OutputFolder, Path.GetFileName(file));
                            string[] _ = outputFilePath.Split('.');
                            outputFilePath = _[0] + ".jpeg";
                            newImage.SetResolution(resolution, resolution);
                            newImage.Save(outputFilePath, ImageFormat.Jpeg);

                            FreeImage.Unload(bitmap);
                        }
                    }
                }
            }

            MessageBox.Show("�������!", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BTN_Crop_Click(object sender, EventArgs e)
        {
            CropImages();
        }

        private void LLB_Input_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (InputFolder != "")
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer", InputFolder);
                }
                catch
                {
                    MessageBox.Show("·��������ȷ��·���Ƿ���ڣ�", "·������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LLB_Output_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OutputFolder != "")
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer", OutputFolder);
                }
                catch
                {
                    MessageBox.Show("·��������ȷ��·���Ƿ���ڣ�", "·������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_SelectInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                InputFolder = folderBrowserDialog.SelectedPath;
                LLB_Input.Text = InputFolder.Split('\\')[^1];
            }
        }

        private void BTN_SelectOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                OutputFolder = folderBrowserDialog.SelectedPath;
                LLB_Output.Text = OutputFolder.Split('\\')[^1];
            }
        }

        private void CB_SetOutputDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_SetOutputDirectory.Checked)
            {
                LLB_Output.Enabled = true;
                BTN_SelectOutput.Enabled = true;
            }
            else
            {
                LLB_Output.Enabled = false;
                BTN_SelectOutput.Enabled = false;
            }
        }

        private void CB_MaxSizeLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_MaxSizeLimit.Checked)
            {
                TB_MaxSizeLimit.Enabled = true;
            }
            else
            {
                TB_MaxSizeLimit.Enabled = false;
            }
        }
    }
}
