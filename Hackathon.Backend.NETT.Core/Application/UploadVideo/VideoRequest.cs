using Microsoft.AspNetCore.Http;

namespace Hackathon.Backend.NETT.Core.Application.UploadVideo
{
    public class VideoRequest
    {
        public IFormFile FileVideo { get; set; }
    }
}
