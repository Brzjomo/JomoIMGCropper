using System.Diagnostics;

namespace JomoIMGCropper
{
    internal class ImageDownloader
    {
        private readonly List<string> _imageUrls;
        private readonly string _downloadPath;
        private readonly int _maxThreads;
        private readonly IProgress<int> _progress; // 使用 IProgress<T> 接口

        public ImageDownloader(List<string> imageUrls, string downloadPath, int maxThreads, IProgress<int> progress)
        {
            _imageUrls = imageUrls;
            _downloadPath = downloadPath;
            int processorCount = Environment.ProcessorCount;
            if (maxThreads >= processorCount) {
                maxThreads = processorCount;
            }
            _maxThreads = maxThreads;
            Debug.WriteLine($"当前使用线程数: {maxThreads}");
            _progress = progress;
        }

        public async Task DownloadImagesAsync()
        {
            _progress.Report(0);

            using var client = new HttpClient();

            await Parallel.ForEachAsync(_imageUrls, new ParallelOptions { MaxDegreeOfParallelism = _maxThreads }, async (imageUrl, cancellationToken) =>
            {
                try
                {
                    var fileName = Path.GetFileName(imageUrl);

                    var imageData = await client.GetByteArrayAsync(imageUrl, cancellationToken);

                    var filePath = Path.Combine(_downloadPath, fileName);

                    if (File.Exists(filePath))
                    {
                        int progressPercentage = _imageUrls.IndexOf(imageUrl) + 1;
                        _progress.Report(progressPercentage);

                        Debug.WriteLine($"跳过已存在图片: {fileName}");
                    } else
                    {
                        File.WriteAllBytes(filePath, imageData);

                        int progressPercentage = _imageUrls.IndexOf(imageUrl) + 1;
                        _progress.Report(progressPercentage);

                        Debug.WriteLine($"已下载图片: {fileName}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"下载图片失败: {imageUrl}, 错误信息: {ex.Message}");
                    MessageBox.Show($"下载图片失败: {imageUrl}\n" + "请确保下载链接可用", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            _progress.Report(_imageUrls.Count);
        }
    }
}
