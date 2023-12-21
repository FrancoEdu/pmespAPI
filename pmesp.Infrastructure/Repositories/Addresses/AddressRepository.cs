using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Interfaces.IAddress;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories.Addresses;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Address> CreateAsync(Address entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Address> DeleteAsync(Address entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<Address>> GetAddressesByBanditIdAsync(string banditId)
    {
        return await _context.AddressBandit
        .Where(aa => aa.BanditsId == banditId)
        .Select(aa => aa.Address)
        .ToListAsync();
    }

    public async Task<ICollection<Address>> GetAllAsync()
    {
        return await _context
                .Addresses
                .AsNoTracking()
                .ToListAsync();
    }

    public async Task<Address> GetByIdAsync(string id)
    {
        return await _context
                .Addresses
                .AsNoTracking()
                .Include(x => x.Bandits)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<Address> UpdateAsync(Address entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
