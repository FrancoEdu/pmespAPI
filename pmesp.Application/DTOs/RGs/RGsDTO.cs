using pmesp.Domain.Entities;
using System;

namespace pmesp.Application.DTOs.RGs;

public class RGsDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Number { get; set; }
    public string Sender { get; set; }
    public string Uf { get; set; }
    public DateTime SenderDate { get; set; }
    public string BanditId { get; set; }
}
