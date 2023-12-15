using pmesp.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities.Common;

public abstract class Person : BaseEntity
{
    public string Name { get; private set; }
    public string? Phone { get; private set; }
    public string? Surname { get; private set; }
    public string? Email { get; private set; }
    public DateTime? Birthday { get; private set; }

    public Person(Guid id,string name, string phone, string surname, string email, DateTime birthday) : base(id)
    {
        id = id;
        ValidateDomain(name, phone, surname, email, birthday);
    }
}

    public Person(string name, string phone, string surname, string email, DateTime birthday)
    {
        ValidateDomain(name,phone,surname,email,birthday);
    }


    public void ValidateDomain(string name, string phone, string surname, string email, DateTime birthday)
    {
        DomainExceptionValidation.When(name.Lenght < 3, "O nome deve ter no mínimo de 3 caracteres");
        DomainExceptionValidation.When(phone.Lenght < 7, "O telefone deve ter no mínimo 7 caracteres");
        DomainExceptionValidation.When(surname.Lenght > 30, "O apelido deve ter menos de 30 caracteres");
        DomainExceptionValidation.When(email.Lenght < 50, "O email deve ter no mínimo 50 caracteres");
        
        
        Name = name;
        Phone = phone;
        Surname = surname;
        Email = email;
        Birthday = birthday;
    }
}
