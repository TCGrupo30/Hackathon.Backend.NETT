using Hackathon.Backend.NETT.Core.Domain;
using Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Infra.Repositories
{
    public class HackathonRepository : IHackathonRepository
    {
        private readonly HackathonDbContext _context;

        public HackathonRepository(HackathonDbContext context) => _context = context;

        public async Task<List<Image>> GetAllImage() => await _context.Images.ToListAsync();

        public async Task<List<Video>> GetAllVideo() => await _context.Videos.ToListAsync();

        public async Task InsertImage(Image video)
        {
            await _context.Images.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task InsertVideo(Video video) 
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }
    }
}
