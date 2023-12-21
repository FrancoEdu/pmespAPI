using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;

namespace pmesp.Application.DTOs.BanditAddresses;

public class BanditAddressesDTO
{
    public string BanditId { get; set; }
    public string AddressId { get; set; }
}
