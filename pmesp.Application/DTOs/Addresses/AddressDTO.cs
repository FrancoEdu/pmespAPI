using pmesp.Application.DTOs.Bandits;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pmesp.Application.DTOs.Addresses;

public class AddressDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? Description { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public ICollection<BanditDTO> Bandits { get; set; }
}
