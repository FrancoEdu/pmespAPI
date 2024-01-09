using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.AssociateAddress;

namespace pmesp.Infrastructure.EntityConfiguration.AssociateAddress;

public class AssociateAddressConfiguration : IEntityTypeConfiguration<AssociateAddresses>
{
    public void Configure(EntityTypeBuilder<AssociateAddresses> builder)
    {
        builder.HasKey(ab => new { ab.AddressesId, ab.BanditsId });

        builder.HasOne(ab => ab.Address)
                .WithMany(a => a.Bandits)
                .HasForeignKey(ab => ab.AddressesId);

        builder.HasOne(ab => ab.Bandit)
                .WithMany(b => b.Addresses)
                .HasForeignKey(ab => ab.BanditsId);
    }
}
