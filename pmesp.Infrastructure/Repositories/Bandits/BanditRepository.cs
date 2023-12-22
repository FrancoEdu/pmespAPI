using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Infrastructure.Context;

namespace pmesp.Infrastructure.Repositories.Bandits;

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

    public async Task<ICollection<Bandit>> GetAllAsync()
    {
        return await _context.Bandits.AsNoTracking().ToListAsync();
    }

    public async Task<ICollection<Bandit>> GetAllInfosAsync()
    {
        return await _context
                .Bandits
                .AsNoTracking()
                .Include(rg => rg.rGs)
                .ToListAsync();
    }

    public async Task<Bandit> GetByCpfAsync(string cpf)
    {
        return await _context.
                Bandits
                .AsNoTracking()
                .Include(rg => rg.rGs)
                .FirstOrDefaultAsync(x => x.CPF.Equals(cpf));
    }

    public async Task<Bandit> GetByEmailAsync(string email)
    {
        return await _context
                .Bandits
                .AsNoTracking()
                .Include(rg => rg.rGs)
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public Task<Bandit> GetByIdAsync(string id)
    {
        return _context
                .Bandits
                .AsNoTracking()
                .Include(rg => rg.rGs)
                .Include(t => t.Tattoos)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<Bandit> GetByNameAsync(string name)
    {
        return await _context
            .Bandits
            .AsNoTracking()
            .Include(rg => rg.rGs)
            .Include(end => end.Addresses)
            .FirstOrDefaultAsync(x => x.Name.Equals(name));
    }

    public async Task<Bandit> UpdateAsync(Bandit entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
