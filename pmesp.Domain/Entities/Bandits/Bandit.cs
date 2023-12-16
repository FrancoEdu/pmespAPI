using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.Bandits;

public class Bandit
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CPF { get; private set; }
    public DateTime Birthday { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string Surname { get; private set; }
    public float Weight { get; private set; }
    public float Height { get; private set; }
    public ICollection<RG> rGs { get; private set; }
    public Bandit(
        string id,
        string name,
        string description,
        string cPF,
        DateTime birthday,
        string phone,
        string email,
        string surname,
        float weight,
        float height)
    {
        Id = id;
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height);
    }

    public void Update(string name,
        string description,
        string cPF,
        DateTime birthday,
        string phone,
        string email,
        string surname,
        float weight,
        float height)
    {
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height);
    }

    public void ValidateDomain(string name,
        string description,
        string cPF,
        DateTime birthday,
        string phone,
        string email,
        string surname,
        float weight,
        float height)
    {
        DomainExceptionValidation.When(name.Length > 30, "O nome não pode ultrapassar os 30 caracteres");
        DomainExceptionValidation.When(description.Length > 255, "A descrição não pode ultrapassar os 255 caracteres");
        DomainExceptionValidation.When(cPF.Length > 14, "O CPF não pode ultrapssar caracteres");
        DomainExceptionValidation.When(birthday > DateTime.Today, "A data de nascimento não pode ser maior que a atual");
        DomainExceptionValidation.When(phone.Length > 12, "O telefone não pode ultrapassar os 12 caracteres");
        DomainExceptionValidation.When(!email.Contains("@"), "O email não tem o formato correto");

        Name = name;
        Description = description;
        CPF = cPF;
        Birthday = birthday;
        Phone = phone;
        Email = email;
        Surname = surname;
        Weight = weight;
        Height = height;
    }
}
