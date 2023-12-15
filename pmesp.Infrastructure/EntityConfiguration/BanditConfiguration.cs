using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pmesp.Domain.Entities;
using pmesp.Domain.Entities.Common;

namespace pmesp.Infrastructure.EntityConfiguration;

internal class BanditConfiguration : IEntityTypeConfiguration<Bandit>
{
    public void Configure(EntityTypeBuilder<Bandit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Phone).HasMaxLength(15);
        builder.Property(x => x.Surname).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Birthday);

        // Relacionamentos
        // Relacionamento com RGs (um Bandit tem várias RGs)
        builder.HasMany(b => b.RGs)
            .WithOne(rg => rg.Person) // Certifique-se de ter a propriedade Person em RG.cs
            .HasForeignKey(rg => rg.PersonId)
            .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão desejado

        // Relacionamento com Addresses (um Bandit tem várias Addresses)
        builder.HasMany(b => b.Adresses)
            .WithOne(a => a.Person) // Certifique-se de ter a propriedade Person em Address.cs
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão desejado

        // Relacionamento com Persons (supondo que Persons é uma lista de parentes)
        builder.HasMany(b => b.Childrens)
            .WithOne(p => p.Bandit) // Define a propriedade de navegação para Bandit em Person.cs
        .HasForeignKey(p => p.BanditId); // Define a chave estrangeira como BanditId em Person.cs
    }
}
