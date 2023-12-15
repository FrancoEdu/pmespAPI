using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.Common;

public abstract class Person : BaseEntity
{
    public string Name { get; private set; }
    public string? Phone { get; private set; }
    public string? Surname { get; private set; }
    public string? Email { get; private set; }
    public DateTime? Birthday { get; private set; }
    public Guid? BanditId { get; set; } // Chave estrangeira para Bandit
    public Bandit Bandit { get; set; } // Propriedade de navegação para Bandit
    public Person(Guid id,string name, string? phone, string? surname, string? email, DateTime? birthday) : base(id)
    {   
        ValidateDomain(name, phone, surname, email, birthday);
    }


    public void ValidateDomain(string name, string? phone, string? surname, string? email, DateTime? birthday)
    {
        DomainExceptionValidation.When(name.Length > 100, "O nome deve ter no máximo 100 caracteres");
        DomainExceptionValidation.When(phone.Length > 15, "O telefone deve ter no máximo 15 caracteres");
        DomainExceptionValidation.When(surname.Length > 30, "O apelido deve ter menos de 30 caracteres");
        DomainExceptionValidation.When(email.Length > 50, "O email deve ter no máximo 50 caracteres");
        
        
        Name = name;
        Phone = phone;
        Surname = surname;
        Email = email;
        Birthday = birthday;
    }
}
