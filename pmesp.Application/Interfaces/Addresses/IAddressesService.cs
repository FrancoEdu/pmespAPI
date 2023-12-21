using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.BanditAddresses;
using pmesp.Application.Services;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Addresses;

public interface IAddressesService
{
    Task<ResultService<AddressDTO>> PostAsync(AddressDTO entity);
}
