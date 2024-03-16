using Hackathon.Backend.NETT.Core.Application.UploadVideo;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Backend.NETT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;

        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Task<IActionResult> Create([FromForm] VideoRequest request)
        {
            return Ok();
        }
    }
}