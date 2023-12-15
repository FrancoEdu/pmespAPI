using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities.Common;

public abstract class Person : BaseEntity
{
    [Required(ErrorMessage = "É necessário enviar o nome")]
    [StringLength(100)]
    public string Name { get; set; }
    [Phone(ErrorMessage = "Parece que o celular não está no padrão")]
    public string? Phone { get; set; }
    [StringLength(100)]
    public string? Surname { get; set; }
    [EmailAddress(ErrorMessage = "Parece que o email não está no padrão")]
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }

}
