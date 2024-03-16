using Hackathon.Backend.NETT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces
{
    public interface IHackathonRepository 
    {
        public Task InsertVideo(Video video);

        public Task<List<Video>> GetAllVideo();

        public Task InsertImage(Image video);

        public Task<List<Image>> GetAllImage();
    }
}
