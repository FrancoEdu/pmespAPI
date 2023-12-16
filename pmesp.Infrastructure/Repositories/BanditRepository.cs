using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories;

public class BanditRepository : IBanditRepository
{
    private readonly ApplicationDbContext _context;

    public BanditRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bandit> CreateAsync(Bandit entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Bandit> DeleteAsync(Bandit entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Bandit>> GetAllAsync()
    {
        return await _context.Bandits.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Bandit>> GetAllInfos()
    {
        return await _context.Bandits.AsNoTracking().Include(rg => rg.rGs).ToListAsync();
    }

    public Task<Bandit> GetByIdAsync(string id)
    {
        return _context.Bandits.AsNoTracking().Include(rg => rg.rGs).FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<Bandit> GetByName(string name)
    {
        return await _context.Bandits.AsNoTracking().Include(rg => rg.rGs).FirstOrDefaultAsync(x => x.Name.Equals(name));
    }

    public async Task<Bandit> UpdateAsync(Bandit entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
