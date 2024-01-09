using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Childs;
using pmesp.Domain.Entities.ChildsBandits;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.Guns;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Entities.SocialMedias;
using pmesp.Domain.Entities.Tattoos;
using pmesp.Domain.Entities.Vehicles;

namespace pmesp.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options){}
    public DbSet<Bandit> Bandits { get; set; }
    public DbSet<AssociateAddresses> AddressBandit {  get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Tattoo> Tattoos { get; set; }
    public DbSet<RG> RGs { get; set; }
    public DbSet<Cop> Cops { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Gun> Guns { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Child> Childs { get; set; }
    public DbSet<ChildBandit> ChildBandit { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}
