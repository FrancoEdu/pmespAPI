using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.DTOs.Cops;

public class CopDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "O nome do policial é obrigatório no cadastro")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O email do policial é obrigatório no cadastro")]
    [EmailAddress(ErrorMessage = "O email não está no formato correto")]
    public string Email { get; set; }
    
    [StringLength(255, ErrorMessage = "A descrição não pode ultrapassar os 255 caracteres")]
    public string? Description { get; set; }
    
    [Required]
    [StringLength(255, ErrorMessage = "A graduação do policial não pode ultrapassar os 5 caracteres")]
    public string Graduation { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "A senha deve ter um tamanho máximo de 15 caracteres")]
    [MinLength(10, ErrorMessage = "A senha deve ter um tamanho mínimo de 10 caracteres")]
    [NotMapped]
    public string Password { get; set; }
}
