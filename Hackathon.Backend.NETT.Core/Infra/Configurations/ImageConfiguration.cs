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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(v => v.ImageId);
            builder.Property(v => v.NameImage).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(v => v.PathImage).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(v => v.CreateAt).HasColumnType("Datetime");
        }
    }
}
