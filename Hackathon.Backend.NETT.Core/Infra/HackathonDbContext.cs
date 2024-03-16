using Hackathon.Backend.NETT.Core.Domain;
using Hackathon.Backend.NETT.Core.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Backend.NETT.Core.Infra
{
    public class HackathonDbContext : DbContext
    {
        public DbSet<Video> Videos => Set<Video>();
        public DbSet<Image> Images => Set<Image>();

        public HackathonDbContext(
            DbContextOptions<HackathonDbContext> options
        ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VideoConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());


            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=tcp:hackafiapnett.database.windows.net,1433;Initial Catalog=hackafiapnett;Persist Security Info=False;User ID=adminhacka;Password=Hacka@2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
