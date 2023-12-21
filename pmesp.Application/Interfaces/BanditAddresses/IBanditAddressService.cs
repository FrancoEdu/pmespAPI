using pmesp.Application.DTOs.BanditAddresses;
using pmesp.Application.Services;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.BanditAddresses;

public interface IBanditAddressService
{
    Task<ResultService<BanditAddressesDTO>> PostAsync(BanditAddressesDTO entity);
}
