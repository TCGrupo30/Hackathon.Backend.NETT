using Microsoft.AspNetCore.Http;

namespace Hackathon.Backend.NETT.Core.Application.CreateVideo
{
    public class CreateVideoRequest
    {
        public IFormFile FileVideo { get; set; }
    }
}
