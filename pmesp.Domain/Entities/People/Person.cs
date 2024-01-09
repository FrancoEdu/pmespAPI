using pmesp.Domain.Validations;
using System.Xml.Linq;

namespace pmesp.Domain.Entities.People;

public class Person
{
    public string Id { get; set; }
    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string? PrincipalPhoto { get; private set; }
    public string? ExtensionPhoto { get; private set; }

    public Person(string id, string name, string cPF)
    {
        Id = id;
        validateDomain(name, cPF);
    }

    public void validateDomain(string name, string cPF)
    {
        DomainExceptionValidation.When(name.Length > 30, "O nome não pode ultrapassar os 30 caracteres");
        Name = name;
        DomainExceptionValidation.When(cPF.Length > 14, "O CPF não pode ultrapssar caracteres");
        CPF = cPF;
    }

    public void updatePersonPhoto(string photo, string extension)
    {
        PrincipalPhoto = photo;
        ExtensionPhoto = extension;
    }
}
