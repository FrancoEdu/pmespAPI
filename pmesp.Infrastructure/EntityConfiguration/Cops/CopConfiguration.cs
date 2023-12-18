using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Cops;

namespace pmesp.Infrastructure.EntityConfiguration.Cops;

public class CopConfiguration : IEntityTypeConfiguration<Cop>
{
    public void Configure(EntityTypeBuilder<Cop> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Graduation).IsRequired();
        builder.Property(x=> x.Description).HasMaxLength(255);
    }
}
