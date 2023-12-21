using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;
using System;
namespace pmesp.Domain.Entities.AssociateAddress;

public class AssociateAddresses
{
    public int BanditId { get; private set; }
    public Bandit Bandit { get;  private set; }
    public int AddressId { get; private set; }
    public Address Address { get; private set; }

    public AssociateAddresses(int banditId, int addressId)
    {
        BanditId = banditId;
        AddressId = addressId;
    }
}
