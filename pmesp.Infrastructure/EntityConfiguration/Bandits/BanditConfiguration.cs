using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Bandits;

namespace pmesp.Infrastructure.EntityConfiguration.Bandits;

internal class BanditConfiguration : IEntityTypeConfiguration<Bandit>
{
    public void Configure(EntityTypeBuilder<Bandit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(30);
        builder.Property(x => x.Phone).HasMaxLength(12);
        builder.Property(x => x.CPF).HasMaxLength(14);
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Email);
        builder.Property(x => x.Birthday);
        builder.Property(x => x.Height);
        builder.Property(x => x.Weight);
        builder.Property(x => x.Surname);
    }
}
