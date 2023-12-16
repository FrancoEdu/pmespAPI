using pmesp.Application.DTOs;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces;

public interface IBanditService : IBaseService<BanditDTO>
{
    Task<BanditDTO> GetBanditAndRGs(string banditId);
}
