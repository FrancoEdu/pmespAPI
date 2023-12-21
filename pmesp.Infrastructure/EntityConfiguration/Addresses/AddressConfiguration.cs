using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;

namespace pmesp.Infrastructure.EntityConfiguration.Addresses;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.ZipCode).HasMaxLength(10);
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.City);
        builder.Property(x => x.State);
        builder.Property(x => x.Country);
    }
}
