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
            string inputFolder = "TrainSets"; // �����ļ���·��
            string outputFolder = "ProcessedTrainSets"; // ����ļ���·��

            int maxSize = 512; // ����Ȼ�߶�
            int resolution = 72; // �ֱ���

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                MessageBox.Show("�������ļ���" + inputFolder + ",\n���ȼ���Ҫ�����ͼƬ������ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // ���ڲ�֧�ֵ�ͼƬ��ʹ��FreeImage�⴦��
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

            MessageBox.Show("�������!", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
