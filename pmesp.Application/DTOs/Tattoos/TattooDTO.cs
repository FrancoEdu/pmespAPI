using System;
using System.Text.Json.Serialization;

namespace pmesp.Application.DTOs.Tattoos;

public class TattooDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string BodyLocation { get; set; }
    public bool Colored { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public string BanditId { get; set; }
}
