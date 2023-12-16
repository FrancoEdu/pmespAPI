using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities;
using pmesp.Domain.Interfaces.Irg;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories;

public class RgRepository : IRgRepository
{
    private readonly ApplicationDbContext _context;

    public RgRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RG> CreateAsync(RG entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<RG> DeleteAsync(RG entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<RG>> GetAllAsync()
    {
        return await _context.RGs.AsNoTracking().ToListAsync();
    }

    public async Task<RG> GetByIdAsync(string id)
    {
        return await _context.RGs.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<RG> UpdateAsync(RG entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
