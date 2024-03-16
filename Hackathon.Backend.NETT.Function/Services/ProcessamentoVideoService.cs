using FFMpegCore;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System;
using System.Threading.Tasks;
using Hackathon.Backend.NETT.Core.Services.Interfaces;

namespace Hackathon.Backend.NETT.Function.Services
{
    public class ProcessamentoVideoService : IProcessamentoVideoService
    {
        private readonly IStorageService _storage;
        public ProcessamentoVideoService(IStorageService storage) 
        {
            _storage = storage;
        }

        public async Task Processar(string filePath)
        {

            var video = await _storage.DownloadFileBlobAsync("teste", filePath);

            var outputFolder = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\Images\";

            Directory.CreateDirectory(outputFolder);

            var videoInfo = FFProbe.Analyse(video);
            var duration = videoInfo.Duration;

            var interval = TimeSpan.FromSeconds(20);

            for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
            {
                var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
                FFMpeg.Snapshot(filePath, outputPath, new Size(1920, 1080), currentTime);
            }

            string destinationZipFilePath = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\images.zip";

            ZipFile.CreateFromDirectory(outputFolder, destinationZipFilePath);
        }
    }
}
