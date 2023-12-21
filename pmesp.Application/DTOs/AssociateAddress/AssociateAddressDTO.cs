using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;

namespace pmesp.Application.DTOs.AssociateAddress;

public  class AssociateAddressDTO
{
    public string BanditsId { get; set; }
    public string AddressesId { get; set; }
}
