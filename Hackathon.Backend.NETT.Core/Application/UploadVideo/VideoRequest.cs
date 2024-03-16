namespace Hackathon.Backend.NETT.Core.Application.UploadVideo
{
    public class VideoRequest
    {
        public string NameVideo { get; set; }
        public IFormFile FileVideo { get; set; }
    }
}
