using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pmesp.Application.DTOs.Cops;

public class CopDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }
    public string Graduation { get; set; }
    
    [NotMapped]
    public string Password { get; set; }
}
