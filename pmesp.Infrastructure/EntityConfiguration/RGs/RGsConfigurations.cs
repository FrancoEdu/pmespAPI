using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.RGs;

namespace pmesp.Infrastructure.EntityConfiguration.RGs;

internal class RGsConfigurations : IEntityTypeConfiguration<RG>
{
    public void Configure(EntityTypeBuilder<RG> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Number).HasMaxLength(15);
        builder.Property(x => x.Sender).HasMaxLength(50);
        builder.Property(x => x.SenderDate);
        builder.Property(x => x.Uf);

        builder.HasOne(r => r.Bandit)
            .WithMany(b => b.rGs)
            .HasForeignKey(r => r.BanditId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
