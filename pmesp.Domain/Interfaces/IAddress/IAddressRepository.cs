﻿using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Interfaces.Base;

namespace pmesp.Domain.Interfaces.IAddress;

public interface IAddressRepository : IRepository<Address>
{
    Task<ICollection<Address>> GetAddressesByBanditIdAsync(string banditId);
    Task<Address> PostAddressUsingBanditIdAsync(AssociateAddresses associateAddresses);
}
