using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Common;

namespace pmesp.Infrastructure.EntityConfiguration;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Phone).HasMaxLength(15);
        builder.Property(x => x.Surname).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Birthday);
    }
}
