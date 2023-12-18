using System.ComponentModel.DataAnnotations;

namespace pmesp.API.Models.Logins;

public class Login
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)] 
    public string Password { get; set; }
}
