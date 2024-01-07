using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.SocialMedias;

namespace pmesp.Infrastructure.EntityConfiguration.SocialMedias;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.InsertDate);
        builder.Property(x => x.Owner);
        builder.Property(x => x.Link);
        builder.Property(x => x.Platform);

        builder.HasOne(r => r.Bandit)
            .WithMany(b => b.SocialMedias)
            .HasForeignKey(r => r.BanditId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
