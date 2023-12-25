using Microsoft.EntityFrameworkCore;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Search;
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

    public async Task<string> Base64PrincipalPhoto(Bandit entity)
    {
        string imagePath = entity.PrincipalPhoto;
        try
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return null;
            }
            byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        catch (FileNotFoundException)
        {
            return null;
        }
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

    public async Task<Bandit> UpdatePhotoAsync(Bandit bandit, string photoPath, string extension)
    {
        bandit.UpdateBanditFoto(photoPath, extension);
        _context.Update(bandit);
        await _context.SaveChangesAsync();
        return bandit;
    }
    public async Task<ICollection<Bandit>> SearchAsync(Searchs searchs)
    {
        int quantityOnDisplay = searchs.QuantityOnDisplay ?? 10;
        int page = searchs.Page ?? 1;

        IQueryable<Bandit> query = _context.Bandits.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchs.Similarity))
        {
            query = query.Where(b =>
                EF.Functions.Like(b.Name, $"%{searchs.Similarity}%") ||
                EF.Functions.Like(b.Surname, $"%{searchs.Similarity}%") ||
                EF.Functions.Like(b.CPF, $"%{searchs.Similarity}%")
            );
        }

        var result = await query
            .OrderBy(b => b.Name)
            .Skip(quantityOnDisplay * (page - 1))
            .Take(quantityOnDisplay)
            .ToListAsync();

        return result;
    }
}
