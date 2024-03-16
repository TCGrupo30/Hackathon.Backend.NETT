using Hackathon.Backend.NETT.Core.Application.CreateVideo;
using Hackathon.Backend.NETT.Core.Application.GetVideo;
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
        private readonly IGetVideoQuery _getVideoQuery;

        public VideoController(ILogger<VideoController> logger,
                               ICreateVideoCommand createVideoCommand,
                               IUploadVideoCommand uploadVideoCommand,
                               IGetVideoQuery getVideoQuery)
        {
            _logger = logger;
            _createVideoCommand = createVideoCommand;
            _uploadVideoCommand = uploadVideoCommand;
            _getVideoQuery = getVideoQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateVideoRequest request)
        {
            var create = _createVideoCommand.Execute(request);

            _ = Task.Run(() => _uploadVideoCommand.Execute(new UploadVideoRequest { }));

            return Ok(await create);
        }

        [HttpGet("GetAllVideos")]
        public async Task<IActionResult> GetAllVideos()
        {
            return Ok(await _getVideoQuery.Execute());
        }
    }
}