using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Interfaces.ICop;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories.Cops;

public class CopsRepository : ICopRepository
{
    public readonly ApplicationDbContext _context;

    public CopsRepository(ApplicationDbContext context)
    {
        _context = context;   
    }

    public async Task<Cop> CreateAsync(Cop entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Cop> DeleteAsync(Cop entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Cop>> GetAllAsync()
    {
        return await _context.Cops.AsNoTracking().ToListAsync();
    }

    public async Task<Cop> GetByIdAsync(string id)
    {
        return await _context.Cops.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<Cop> UpdateAsync(Cop entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
