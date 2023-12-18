using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.Cops;

public class Cop
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string? Description { get; private set; }
    public string Graduation { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

    public Cop(string id,string email, string name, string? description, string graduation)
    {
        Id = id;
        ValidateDomain(email, name, description, graduation);  
    }

    public Cop(string email, string name, string? description, string graduation)
    {
        ValidateDomain(email, name, description, graduation);
    }

    public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public void ValidateDomain(string email, string name, string? description, string graduation)
    {
        if (description != null)
        {
            DomainExceptionValidation.When(description.Length > 255, "A descrição não pode ultrapassar os 255 caracteres");
        }
        Description = description;

        DomainExceptionValidation.When(!email.Contains("@"), "O email não tem o formato correto");
        DomainExceptionValidation.When(email == null, "O email do policial cadastrado é obrigatório");
        Email = email;

        DomainExceptionValidation.When(name == null, "O nome do policial cadastrado é obrigatório");
        Name = name;

        DomainExceptionValidation.When(graduation == null, "A graduação do policial é obrigatório");
        DomainExceptionValidation.When(graduation.Length > 5, "Por favor, abrevie a graduação, ex: CB PM Henrique");
        Graduation = graduation;
    }
}
