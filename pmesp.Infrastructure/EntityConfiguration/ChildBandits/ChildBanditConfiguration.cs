using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.ChildsBandits;

namespace pmesp.Infrastructure.EntityConfiguration.ChildBandits;

public class ChildBanditConfiguration : IEntityTypeConfiguration<ChildBandit>
{
    public void Configure(EntityTypeBuilder<ChildBandit> builder)
    {
        builder.HasKey(ab => new { ab.ChildId, ab.BanditsId });

        builder.HasOne(x => x.Child)
            .WithMany(a => a.Bandits)
            .HasForeignKey(y => y.ChildId);

        builder.HasOne(x => x.Bandit)
            .WithMany(a => a.Childs)
            .HasForeignKey(y => y.ChildId);
    }
}
