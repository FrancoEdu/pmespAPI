using pmesp.Domain.Entities.Tattoos;
using pmesp.Domain.Interfaces;
using pmesp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Infrastructure.Repositories.Tattoos;

public class TattooRepository : ITattooRepository
{
    private readonly ApplicationDbContext _context;

    public TattooRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Tattoo> PostAsync(Tattoo tattoo)
    {
        _context.Add(tattoo);
        await _context.SaveChangesAsync();
        return tattoo;
    }
}
