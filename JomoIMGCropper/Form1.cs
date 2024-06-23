using FreeImageAPI;
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
                try
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open))
                    {
                        using (Image image = Image.FromStream(stream, false, false))
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

                            string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(file));
                            string[] _ = outputFilePath.Split('.');
                            outputFilePath = _[0] + ".jpeg";
                            newImage.SetResolution(resolution, resolution);
                            newImage.Save(outputFilePath, ImageFormat.Jpeg);
                        }
                    }
                }
                catch
                {
                    // 对于不支持的图片，使用FreeImage库处理
                    FIBITMAP bitmap = FreeImage.LoadEx(file);

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

                        string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(file));
                        string[] _ = outputFilePath.Split('.');
                        outputFilePath = _[0] + ".jpeg";
                        newImage.SetResolution(resolution, resolution);
                        newImage.Save(outputFilePath, ImageFormat.Jpeg);

                        FreeImage.Unload(bitmap);
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
