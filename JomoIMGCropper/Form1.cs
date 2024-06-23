using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace JomoIMGCropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CropImages()
        {
            string inputFolder = "TrainSets"; // 输入文件夹路径
            string outputFolder = "ProcessedTrainSets"; // 输出文件夹路径

            int maxSize = 512; // 最大宽度或高度
            int resolution = 72; // 分辨率

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                MessageBox.Show("不存在文件夹" + inputFolder + ",\n请先加需要处理的图片放入该文件夹", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] files = Directory.GetFiles(inputFolder);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                ImageCodecInfo codec = Array.Find(ImageCodecInfo.GetImageEncoders(), c => c.FilenameExtension.ToLower().Contains(extension));
                if (codec == null)
                {
                    Console.WriteLine($"跳过不支持的文件格式: {Path.GetFileName(file)}");
                    continue;
                }

                using (Image originalImage = Image.FromFile(file))
                {
                    int width = originalImage.Width;
                    int height = originalImage.Height;

                    int newWidth, newHeight;
                    int startX, startY;

                    if (width > height)
                    {
                        newWidth = maxSize;
                        newHeight = (int)((double)height / width * maxSize);
                        startX = 0;
                        startY = (maxSize - newHeight) / 2;
                    }
                    else
                    {
                        newWidth = (int)((double)width / height * maxSize);
                        newHeight = maxSize;
                        startX = (maxSize - newWidth) / 2;
                        startY = 0;
                    }

                    using (Bitmap resizedImage = new Bitmap(maxSize, maxSize))
                    {
                        resizedImage.SetResolution(resolution, resolution);

                        using (Graphics g = Graphics.FromImage(resizedImage))
                        {
                            g.FillRectangle(Brushes.White, 0, 0, maxSize, maxSize); // 先填充白色背景
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(originalImage, startX, startY, newWidth, newHeight); // 绘制原始图片在中心
                        }

                        string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(file));
                        resizedImage.Save(outputFilePath, codec, null);
                    }
                }
            }
        }

        private void BTN_Crop_Click(object sender, EventArgs e)
        {
            CropImages();

            MessageBox.Show("处理完成!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
