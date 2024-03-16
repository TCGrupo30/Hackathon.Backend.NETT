using FFMpegCore;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using System.IO.Compression;
using System.IO;
using System;
using System.Threading.Tasks;
using Hackathon.Backend.NETT.Core.Services.Interfaces;
using System.Drawing;

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
        
            var name = "Marvel_DOTNET_CSHARP.mp4";
            var video = await _storage.DownloadFileBlobAsync(name, "https://hackafiapnett.blob.core.windows.net/blobhackanett/");

            var outputFolder = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\teste\Images\";

            Directory.CreateDirectory(outputFolder);

            var videoInfo = FFProbe.Analyse(video);
            var duration = videoInfo.Duration;

            var interval = TimeSpan.FromSeconds(20);

            for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
            {
                var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
                FFMpeg.Snapshot(filePath, outputPath, new Size(1920, 1080), currentTime);
            }

            string destinationZipFilePath = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\teste\images.zip";

            ZipFile.CreateFromDirectory(outputFolder, destinationZipFilePath);
        }
    }
}
