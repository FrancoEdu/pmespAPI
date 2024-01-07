using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Vehicles;

namespace pmesp.Infrastructure.EntityConfiguration.Vehicles;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Model).HasMaxLength(30);
        builder.Property(x => x.Brand).HasMaxLength(12);
        builder.Property(x => x.Plate).HasMaxLength(12);
        builder.Property(x => x.CPFowner).HasMaxLength(14);
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Color);

        builder.HasOne(r => r.Bandit)
            .WithMany(b => b.Vehicles)
            .HasForeignKey(r => r.BanditId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
