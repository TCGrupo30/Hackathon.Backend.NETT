using Hackathon.Backend.NETT.Core.Application.CreateVideo;
using Hackathon.Backend.NETT.Core.Application.UploadVideo;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Backend.NETT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;
        private readonly ICreateVideoCommand _createVideoCommand;
        private readonly IUploadVideoCommand _uploadVideoCommand;

        public VideoController(ILogger<VideoController> logger,
                               ICreateVideoCommand createVideoCommand,
                               IUploadVideoCommand uploadVideoCommand)
        {
            _logger = logger;
            _createVideoCommand = createVideoCommand;
            _uploadVideoCommand = uploadVideoCommand;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateVideoRequest request)
        {
            var create = await _createVideoCommand.Execute(request);

            _ = _uploadVideoCommand.Execute(new UploadVideoRequest { });

            return Ok(create);
        }
    }
}