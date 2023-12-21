using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;
using System;
namespace pmesp.Domain.Entities.AssociateAddress;

public class AssociateAddresses
{
    public string BanditsId { get; private set; }
    public Bandit Bandit { get;  private set; }
    public string AddressesId { get; private set; }
    public Address Address { get; private set; }

    public AssociateAddresses(string banditId, string addressId)
    {
        BanditsId = banditId;
        AddressesId = addressId;
    }
}
