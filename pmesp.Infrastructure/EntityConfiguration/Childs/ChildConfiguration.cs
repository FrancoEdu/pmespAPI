using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities.Childs;
using pmesp.Domain.Entities.ChildsBandits;

namespace pmesp.Infrastructure.EntityConfiguration.Childs;

public class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(30);
        builder.Property(x => x.CPF).HasMaxLength(14);
        builder.Property(x => x.PrincipalPhoto);
        builder.Property(x => x.ExtensionPhoto);
        builder.Property(x => x.SchoolPeriod);
    }
}
