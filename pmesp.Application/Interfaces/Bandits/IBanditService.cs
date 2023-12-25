using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.SearchDTO;
using pmesp.Application.Interfaces.Base;
using pmesp.Application.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Bandits;

public interface IBanditService : IBaseService<BanditDTO>
{
    Task<ResultService<BanditDTO>> PostAddressUsingBanditId(BanditAddressDTO banditAddressDTO);
    Task<ResultService<BanditDTO>> UpdatePhotoPrincipalBanditAsync(string banditId, UpdateImageBanditDTO photo);
    Task<ResultService<ICollection<BanditDTO>>> SearchAsync(SearchDTO searchDTO);
}
