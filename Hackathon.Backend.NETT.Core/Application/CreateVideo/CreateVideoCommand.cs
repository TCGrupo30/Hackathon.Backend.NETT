
using Hackathon.Backend.NETT.Core.Domain;
using Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces;

namespace Hackathon.Backend.NETT.Core.Application.CreateVideo
{
    public class CreateVideoCommand : ICreateVideoCommand
    {
        private readonly IHackathonRepository _hackathonRepository;
        public CreateVideoCommand(IHackathonRepository hackathonRepository)
        {
            _hackathonRepository = hackathonRepository;
        }

        public async Task<CreateVideoResponse> Execute(CreateVideoRequest request)
        {
            var video = new Video()
            {
                CreateAt = DateTime.Now,
                NameZip = request.FileVideo.FileName,
                VideoId = Guid.NewGuid()
            };


            await _hackathonRepository.InsertVideo(video);



            return new CreateVideoResponse() { VideoId = video.VideoId};
        }
    }
}
