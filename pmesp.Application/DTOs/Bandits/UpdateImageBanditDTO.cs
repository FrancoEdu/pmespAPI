using Microsoft.AspNetCore.Http;

namespace pmesp.Application.DTOs.Bandits;

public class UpdateImageBanditDTO
{
    public IFormFile Photo { get; set; }
}
