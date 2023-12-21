using pmesp.Domain.Entities.BanditAddresses;
using pmesp.Domain.Interfaces.IBanditAddresses;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories.BanditAddresses;

public class BanditAddressesRepository : IBanditAddressesRepository
{
    private readonly ApplicationDbContext _context;

    public BanditAddressesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BanditAddress> CreateAsync(BanditAddress entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
