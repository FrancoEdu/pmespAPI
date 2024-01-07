using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Vehicles;
using pmesp.Domain.Entities.Guns;

namespace pmesp.Infrastructure.EntityConfiguration.Guns;

public class GunConfiguration : IEntityTypeConfiguration<Gun>
{
    public void Configure(EntityTypeBuilder<Gun> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Model).HasMaxLength(30);
        builder.Property(x => x.Brand).HasMaxLength(12);
        builder.Property(x => x.Numeration).HasMaxLength(15);
        builder.Property(x => x.Caliber).HasMaxLength(5);
        builder.Property(x => x.National);
        builder.Property(x => x.Shaved);

        builder.HasOne(r => r.Bandit)
            .WithMany(b => b.Guns)
            .HasForeignKey(r => r.BanditId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
