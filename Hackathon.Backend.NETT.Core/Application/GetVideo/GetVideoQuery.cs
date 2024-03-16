using Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Application.GetVideo
{
    public class GetVideoQuery : IGetVideoQuery
    {
        private readonly IHackathonRepository _hackathonRepository;
        public GetVideoQuery(IHackathonRepository hackathonRepository)
        {
            _hackathonRepository = hackathonRepository;
        }

        public async Task<List<GetVideoResponse>> Execute()
        {
            var videos = await _hackathonRepository.GetAllVideo();

            var videoReturn = new List<GetVideoResponse>();

            foreach (var item in videos)
            {
                videoReturn.Add(new GetVideoResponse { VideoId = item.VideoId, NameZip = item.NameZip});
            }

            return videoReturn;
        }
    }
}
