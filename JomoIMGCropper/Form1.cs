using FreeImageAPI;
using System.Drawing.Imaging;
using System.Text;

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
                MessageBox.Show("尚未设置输入或输出文件夹" + ",\n请先设置后再运行", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CB_SetOutputDirectory.Checked)
            {
                OutputFolder = InputFolder + "\\" + "ProcessedTrainSets";
            }

            int maxSize = 512; // 最大宽度或高度

            try
            {
                maxSize = Int16.Parse(TB_MaxSizeLimit.Text);
            }
            catch
            {
                MessageBox.Show("图片最大尺寸设置错误" + ",\n请检查是否为数字", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resolution = 72; // 分辨率

            if (!Directory.Exists(InputFolder))
            {
                Directory.CreateDirectory(InputFolder);
                MessageBox.Show("不存在文件夹" + InputFolder + ",\n请先加需要处理的图片放入该文件夹", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            }
                            else
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
                    // 对于不支持的图片，使用FreeImage库处理
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
                    }
                    else
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

            MessageBox.Show("处理完成!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("路径错误！请确认路径是否存在！", "路径错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("路径错误！请确认路径是否存在！", "路径错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // 图片下载器
        private static string linksFile = String.Empty;
        private static string imgSaveFolder = String.Empty;
        private static List<string> imageUrls = [];

        private void LLB_LinksFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linksFile != "")
            {
                string[] fileName = linksFile.Split("\\");
                string fileFolderPath = linksFile.Replace(fileName[^1], "");

                try
                {
                    System.Diagnostics.Process.Start("explorer", fileFolderPath);
                }
                catch
                {
                    MessageBox.Show("路径错误！请确认路径是否存在！", "路径错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LLB_SavePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (imgSaveFolder != "")
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer", imgSaveFolder);
                }
                catch
                {
                    MessageBox.Show("路径错误！请确认路径是否存在！", "路径错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_SelectLinksFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                FileName = "选择一个txt文件",
                Filter = "txt文件(*.txt)|*.txt",
                Title = "打开txt文件"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                linksFile = openFileDialog.FileName;

                string[] fileName = openFileDialog.FileName.Split("\\");
                string openFileName = fileName[^1];
                LLB_LinksFile.Text = openFileName;
            }
        }

        private void BTN_SelectSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                imgSaveFolder = folderBrowserDialog.SelectedPath;
                LLB_SavePath.Text = imgSaveFolder.Split('\\')[^1];
            }
        }

        private async void BTN_Download_Click(object sender, EventArgs e)
        {
            if (linksFile == String.Empty)
            {
                MessageBox.Show("请先选择包含下载链接的txt文件", "未指定下载链接", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (imgSaveFolder == String.Empty)
            {
                MessageBox.Show("请先指定保存图片的目录", "未指定保存目录", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await GetLinksFromFile();

            if (imageUrls.Count < 1)
            {
                MessageBox.Show("请确保txt文件中下载链接不为空", "链接为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PB_Download.Maximum = imageUrls.Count;
            var progress = new Progress<int>(value =>
            {
                UpdateProgressBar(value);
            });

            var downloader = new ImageDownloader(imageUrls, imgSaveFolder, (int)NUD_MaxThreads.Value, progress);
            await downloader.DownloadImagesAsync();

            MessageBox.Show("下载完成!", "完成", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void UpdateProgressBar(int value)
        {
            if (PB_Download.InvokeRequired)
            {
                PB_Download.Invoke(new Action<int>(UpdateProgressBar), value);
            }
            else
            {
                PB_Download.Value = value;
            }
        }

        private async static Task GetLinksFromFile()
        {
            imageUrls.Clear();

            var inputStream = new StreamReader(linksFile, Encoding.UTF8);
            var input = await inputStream.ReadToEndAsync();
            inputStream.Close();

            string[] inputString = input.Split(['\r', '\n']);

            foreach (var line in inputString)
            {
                if (line != "")
                {
                    if (line.Contains('\t'))
                    {
                        imageUrls.Add(line.Trim(['\t']));
                    }
                    else
                    {
                        imageUrls.Add(line);
                    }
                }
            }
        }
    }
}
