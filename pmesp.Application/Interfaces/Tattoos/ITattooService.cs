using pmesp.Application.DTOs.Tattoos;
using pmesp.Application.Services;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Tattoos;

public interface ITattooService
{
    Task<ResultService<TattooDTO>> PostAsync(TattooDTO dto);
}
