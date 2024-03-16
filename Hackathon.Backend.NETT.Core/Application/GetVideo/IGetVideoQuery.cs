using Hackathon.Backend.NETT.Core.Application.CreateVideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Application.GetVideo
{
    public interface IGetVideoQuery
    {
        Task<List<GetVideoResponse>> Execute();
    }
}
