using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities;
using pmesp.Domain.Entities.Common;

namespace pmesp.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options){}
    public DbSet<Bandit> Bandits { get; set; }
    public DbSet<RG> RGs { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}
