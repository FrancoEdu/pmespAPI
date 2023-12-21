using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.BanditAddresses;

namespace pmesp.Infrastructure.EntityConfiguration.BanditAddresses;

public class BanditAddressConfiguration : IEntityTypeConfiguration<BanditAddress>
{
    public void Configure(EntityTypeBuilder<BanditAddress> builder)
    {
        builder.HasKey(be => new { be.BanditId, be.AddressId });

        builder.HasOne(be => be.Bandit)
            .WithMany(b => b.Addresses)
            .HasForeignKey(be => be.BanditId);

        builder.HasOne(be => be.Address)
            .WithMany(a => a.Bandits)
            .HasForeignKey(be => be.AddressId);
    }
}
