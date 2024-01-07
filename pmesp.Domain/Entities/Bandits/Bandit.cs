using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Guns;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Entities.SocialMedias;
using pmesp.Domain.Entities.Tattoos;
using pmesp.Domain.Entities.Vehicles;
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
    public string? Nationality { get; private set; }
    public string? Naturalness { get; private set; }
    public string? MaritalStatus { get; private set; }
    public string? CriminalSituation { get; private set; }
    public string? ORCRIM { get; private set; }
    public string? CrimeFunction { get; private set; }
    public string? Profession { get; private set; }
    public string? CriminalRG { get; private set; }
    public string? ChainRegistration { get; private set; }
    public string? OperationPhone { get; private set; }
    public string? WhatsApp { get; private set; }
    public string? PixEmail { get; private set; }
    public string? PixPhone { get; private set; }
    public string? PixCPF { get; private set; }
    public ICollection<Tattoo> Tattoos { get; private set; }
    public ICollection<RG> rGs { get; private set; }
    public ICollection<Vehicle> Vehicles { get; private set; }
    public ICollection<Gun> Guns { get; private set; }
    public ICollection<SocialMedia> SocialMedias { get; private set; }
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
        string? extension,
        string? nationality, 
        string? naturalness, 
        string? maritalStatus, 
        string? criminalSituation, 
        string? oRCRIM, 
        string? crimeFunction, 
        string? profession, 
        string? criminalRG, 
        string? chainRegistration, 
        string? operationPhone, 
        string? whatsApp, 
        string? pixEmail, 
        string? pixPhone, 
        string? pixCPF)
    {
        Id = id;
        rGs = new List<RG>();
        Tattoos = new List<Tattoo>();
        Addresses = new List<AssociateAddresses>();
        Vehicles = new List<Vehicle>();
        Guns = new List<Gun>();
        SocialMedias = new List<SocialMedia>();
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height, photo, extension, nationality, naturalness, maritalStatus, criminalSituation, oRCRIM, crimeFunction, profession, criminalRG, chainRegistration, operationPhone, whatsApp, pixEmail, pixPhone, pixCPF);
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
        string? extension,
        string? nationality,
        string? naturalness,
        string? maritalStatus,
        string? criminalSituation,
        string? oRCRIM,
        string? crimeFunction,
        string? profession,
        string? criminalRG,
        string? chainRegistration,
        string? operationPhone,
        string? whatsApp,
        string? pixEmail,
        string? pixPhone,
        string? pixCPF)
    {
        ValidateDomain(name, description, cPF, birthday, phone, email, surname, weight, height, photo, extension, nationality, naturalness, maritalStatus, criminalSituation, oRCRIM, crimeFunction, profession, criminalRG, chainRegistration, operationPhone, whatsApp, pixEmail, pixPhone, pixCPF);
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
        string? extension,
        string? nationality,
        string? naturalness,
        string? maritalStatus,
        string? criminalSituation,
        string? oRCRIM,
        string? crimeFunction,
        string? profession,
        string? criminalRG,
        string? chainRegistration,
        string? operationPhone,
        string? whatsApp,
        string? pixEmail,
        string? pixPhone,
        string? pixCPF)
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
        Nationality = nationality;
        Naturalness = naturalness;
        MaritalStatus = maritalStatus;
        ORCRIM = oRCRIM;
        CrimeFunction = crimeFunction;
        Profession = profession;
        CriminalRG = criminalRG;
        ChainRegistration = chainRegistration;
        CriminalSituation = criminalSituation;
        OperationPhone = operationPhone;
        WhatsApp = whatsApp;
        PixEmail = pixEmail;
        PixPhone = pixPhone;
        PixCPF = pixCPF;
    }
}
