using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Base;
using pmesp.Application.Services;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Bandits;

public interface IBanditService : IBaseService<BanditDTO>
{
    Task<ResultService<BanditDTO>> PostAddressUsingBanditId(BanditAddressDTO banditAddressDTO);
}
