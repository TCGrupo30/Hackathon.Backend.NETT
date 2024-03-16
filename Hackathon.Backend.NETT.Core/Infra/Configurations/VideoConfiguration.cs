using Hackathon.Backend.NETT.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Infra.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(v => v.VideoId);
            builder.Property(v => v.NameZip).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(v => v.PathZip).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(v => v.CreateAt).HasColumnType("Datetime");
        }
    }
}
