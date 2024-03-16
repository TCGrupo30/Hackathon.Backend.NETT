using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Application.UploadVideo
{
    public interface IUploadVideoCommand
    {
        Task<UploadVideoResponse> Execute(UploadVideoRequest request);
    }
}
