using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Base;
using pmesp.Domain.Entities.Response;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Bandits;

public interface IBanditService : IBaseService<BanditDTO>
{
    Task<Response<BanditDTO>> GetBanditAndRGs(string banditId);
    Task<Response<BanditDTO>> GetBanditByName(string name);
}
