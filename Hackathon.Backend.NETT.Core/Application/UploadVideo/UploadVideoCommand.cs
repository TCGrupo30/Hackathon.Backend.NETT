using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Application.UploadVideo
{
    public class UploadVideoCommand : IUploadVideoCommand
    {
        public Task<UploadVideoResponse> Execute(UploadVideoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
