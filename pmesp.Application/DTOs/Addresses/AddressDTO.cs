using pmesp.Domain.Entities.BanditAddresses;
using System;
using System.Collections.Generic;

namespace pmesp.Application.DTOs.Addresses;

public class AddressDTO
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public ICollection<BanditAddress> banditAddresses { get; private set; }
}
