using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using pmesp.Application.DTOs.RGs;

namespace pmesp.Application.DTOs.Bandits;

public class BanditDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? Description { get; set; }
    public string CPF { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Surname { get; set; }
    public float? Weight { get; set; }
    public float? Height { get; set; }
    public ICollection<RGsDTO> RGs { get; set; }
}
