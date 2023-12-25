using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Entities.Tattoos;
using pmesp.Domain.Validations;
using System.Text.Json.Serialization;

namespace pmesp.Domain.Entities.Bandits;

public class Bandit
{
    public string Id { get; set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string CPF { get; private set; }
    public DateTime? Birthday { get; private set; }
    public string? Phone { get; private set; }
    public string? Email { get; private set; }
    public string? Surname { get; private set; }
    public float? Weight { get; private set; }
    public float? Height { get; private set; }
    public string? PrincipalPhoto { get; private set; }
    public string? ExtensionPhoto { get; private set; } 
    public ICollection<Tattoo> Tattoos { get; private set; }
    public ICollection<RG> rGs { get; private set; }
    public ICollection<AssociateAddresses> Addresses { get; private set; }

    public Bandit()
    {
        
    }
    public Bandit(
        string id,
        string name,
        string? description,
        string cPF,
        DateTime? birthday,
        string? phone,
        string? email,
        string? surname,
        float? weight,
        float? height,
        string? photo,
        string? extension)
    {
        Id = id;
        rGs = new List<RG>();
        Tattoos = new List<Tattoo>();
        Addresses = new List<AssociateAddresses>();
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height, photo, extension);
    }

    public void Update(string name,
        string? description,
        string cPF,
        DateTime? birthday,
        string? phone,
        string? email,
        string? surname,
        float? weight,
        float? height,
        string? photo,
        string? extension)
    {
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height, photo, extension);
    }

    public void UpdateBanditFoto(string photo, string extension)
    {
        PrincipalPhoto = photo;
        ExtensionPhoto = extension;
    }

    public void ValidateDomain(string name,
        string? description,
        string cPF,
        DateTime? birthday,
        string? phone,
        string? email,
        string? surname,
        float? weight,
        float? height,
        string? photo,
        string? extension)
    {
        DomainExceptionValidation.When(name.Length > 30, "O nome não pode ultrapassar os 30 caracteres");
        if(description != null)
        {
            DomainExceptionValidation.When(description.Length > 255, "A descrição não pode ultrapassar os 255 caracteres");
        }
        DomainExceptionValidation.When(cPF.Length > 14, "O CPF não pode ultrapssar caracteres");
        if(birthday != null)
        {
            DomainExceptionValidation.When(birthday > DateTime.Today, "A data de nascimento não pode ser maior que a atual");
        }
        if(phone != null)
        {
            DomainExceptionValidation.When(phone.Length > 12, "O telefone não pode ultrapassar os 12 caracteres");
        }
        if (email != null)
        {
            DomainExceptionValidation.When(!email.Contains("@"), "O email não tem o formato correto");
        }

        Name = name;
        Description = description;
        CPF = cPF;
        Birthday = birthday;
        Phone = phone;
        Email = email;
        Surname = surname;
        Weight = weight;
        Height = height;
        PrincipalPhoto = photo;
        ExtensionPhoto = extension;
    }
}
