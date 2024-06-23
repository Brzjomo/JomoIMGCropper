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
                string extension = Path.GetExtension(file).ToLower();

                ImageCodecInfo codec = Array.Find(ImageCodecInfo.GetImageEncoders(), c => c.FilenameExtension.ToLower().Contains(extension));
                if (codec == null)
                {
                    Console.WriteLine($"������֧�ֵ��ļ���ʽ: {Path.GetFileName(file)}");
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
                            g.FillRectangle(Brushes.White, 0, 0, maxSize, maxSize); // ������ɫ����
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(originalImage, startX, startY, newWidth, newHeight); // ����ԭʼͼƬ������
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

            MessageBox.Show("�������!", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
