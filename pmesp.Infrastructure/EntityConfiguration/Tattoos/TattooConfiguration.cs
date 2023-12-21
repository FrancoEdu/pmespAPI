using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Entities.Tattoos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Infrastructure.EntityConfiguration.Tattoos;

public class TattooConfiguration : IEntityTypeConfiguration<Tattoo>
{
    public void Configure(EntityTypeBuilder<Tattoo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.BodyLocation).HasMaxLength(30);
        builder.Property(x => x.Description);
        builder.Property(x => x.Colored);

        builder.HasOne(r => r.Bandit)
              .WithMany(r => r.Tattoos)
              .HasForeignKey(r => r.BanditId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
