using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.RGs;

namespace pmesp.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options){}
    public DbSet<Bandit> Bandits { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<RG> RGs { get; set; }
    public DbSet<Cop> Cops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}
