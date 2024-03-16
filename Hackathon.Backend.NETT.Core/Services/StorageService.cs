using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hackathon.Backend.NETT.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Services
{
    public class StorageService : IStorageService
    {

        private BlobContainerClient _container;
        private const string containerName = "blobhackanett";
        public StorageService()
        {
            _container = new BlobContainerClient("", containerName);
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, Stream fileStream)
        {
            try
            {
                var createResponse = await _container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await _container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = _container.GetBlobClient(strFileName);

                await blob.DeleteIfExistsAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
                await blob.UploadAsync(fileStream);

                var urlString = blob.Uri.ToString();
                return urlString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stream> DownloadFileBlobAsync(string fileName)
        {
            var blobClient = _container.GetBlobClient(fileName);
            return (await blobClient.DownloadStreamingAsync()).Value.Content;
        }

    }
}
