using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Validations;
using System.Text.Json.Serialization;

namespace pmesp.Domain.Entities.Addresses;

public class Address
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public ICollection<AssociateAddresses> Bandits { get; private set; }

    public Address(string id, string name, string? description, string zipCode, string city, string state, string country)
    {
        Id = id;
        Bandits = new List<AssociateAddresses>();
        ValidateDomain(name, description, zipCode, city, state, country);
    }

    public void Update(string? name,
        string? description,
        string? zipCode,
        string? city,
        string? state,
        string? country)
    {
        ValidateDomain(name, description, zipCode, city, state, country);
    }

    public void ValidateDomain
    (
        string name,
        string? description,
        string zipCode,
        string city,
        string state,
        string country
    )
    {
        DomainExceptionValidation.When(name.Length > 50, "O nome da rua não pode ultrapassar os 50 caracteres");
        Name = name;
        
        if (description != null)
        {
            DomainExceptionValidation.When(description.Length > 255, "A descrição não pode ultrapassar os 255 caracteres");
        }
        Description = description;

        DomainExceptionValidation.When(zipCode.Length > 10, "O CEP da redidência não pode ultrapassar os 10 caracteres");
        ZipCode = zipCode;
        
        City = city;
        State = state;
        Country = country;
    }
}
