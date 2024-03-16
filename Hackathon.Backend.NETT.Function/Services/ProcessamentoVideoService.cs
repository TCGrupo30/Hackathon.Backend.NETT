using FFMpegCore;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using System.IO.Compression;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Drawing;
using Hackathon.Backend.NETT.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces;
using Hackathon.Backend.NETT.Core.Infra.Repositories;
using Hackathon.Backend.NETT.Core.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace Hackathon.Backend.NETT.Function.Services
{
    public class ProcessamentoVideoService : IProcessamentoVideoService
    {
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storage;
        private readonly IHackathonRepository _hackathonRepository;
        private string blobPath;
        private string outputFolder;
        private string destinationZipFilePath;

        public ProcessamentoVideoService(IStorageService storage, IConfiguration configuration, IHackathonRepository hackathonRepository) 
        {
            _storage = storage;
            _configuration = configuration;
            _hackathonRepository = hackathonRepository;      
        }

        public async Task Processar(string fileName)
        {
            blobPath = _configuration["blobUrl"];
            outputFolder = _configuration["outputFolder"];
            destinationZipFilePath = _configuration["destinationZipFilePath"];

            var video = await _storage.DownloadFileBlobAsync(fileName);

            Directory.CreateDirectory(outputFolder);

            var videoInfo = FFProbe.Analyse(video);
            var duration = videoInfo.Duration;

            var interval = TimeSpan.FromSeconds(20);

            for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
            {
                var filePath = string.Concat(blobPath, fileName);
                var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
                FFMpeg.Snapshot(filePath, outputPath, new Size(1920, 1080), currentTime);
             
            }

            ZipFile.CreateFromDirectory(outputFolder, destinationZipFilePath);
        }
    }
}
