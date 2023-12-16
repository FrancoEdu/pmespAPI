using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Base;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Bandits;

public interface IBanditService : IBaseService<BanditDTO>
{
    Task<BanditDTO> GetBanditAndRGs(string banditId);
    Task<BanditDTO> GetBanditByName(string name);
}
