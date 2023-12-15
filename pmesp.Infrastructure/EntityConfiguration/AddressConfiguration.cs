using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities;

namespace pmesp.Infrastructure.EntityConfiguration;

internal class AddressConfiguration : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AdressOne).HasMaxLength(100);
        builder.Property(x => x.Neighborhood).HasMaxLength(50);
        builder.Property(x => x.City).HasMaxLength(50);
        builder.Property(x => x.State).HasMaxLength(2);
        builder.Property(x => x.Country).HasMaxLength(20);
        builder.Property(x => x.ZipCode).HasMaxLength(9);

        // Relacionamentos

    }
}
