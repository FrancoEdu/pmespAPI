using System.ComponentModel.DataAnnotations;

namespace pmesp.API.Models.Logins;

public class LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}
