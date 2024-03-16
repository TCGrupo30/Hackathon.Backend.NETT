using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Services.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadFileToBlobAsync(string strFileName, Stream fileStream);
        Task<Stream> DownloadFileBlobAsync(string fileName, string downloadFilePath)
    }
}
