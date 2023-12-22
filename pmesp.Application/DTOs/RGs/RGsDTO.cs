using pmesp.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace pmesp.Application.DTOs.RGs;

public class RGsDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Number { get; set; }
    public string Sender { get; set; }
    public string Uf { get; set; }
    public DateTime SenderDate { get; set; }
    [JsonIgnore]
    public string BanditId { get; set; }
}
