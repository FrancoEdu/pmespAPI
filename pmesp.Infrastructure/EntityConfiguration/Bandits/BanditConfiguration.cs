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
        builder.Property(x => x.PrincipalPhoto);
        builder.Property(x => x.ExtensionPhoto);
        builder.Property(x => x.Nationality);
        builder.Property(x => x.Naturalness);
        builder.Property(x => x.MaritalStatus);
        builder.Property(x => x.ChainRegistration);
        builder.Property(x => x.CriminalSituation);
        builder.Property(x => x.ORCRIM);
        builder.Property(x => x.CrimeFunction);
        builder.Property(x => x.Profession);
        builder.Property(x => x.CriminalRG);
        builder.Property(x => x.OperationPhone);
        builder.Property(x => x.WhatsApp);
        builder.Property(x => x.PixEmail);
        builder.Property(x => x.PixCPF);
        builder.Property(x => x.PixPhone);
    }
}
