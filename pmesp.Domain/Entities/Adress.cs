using pmesp.Domain.Entities.Common;
using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities;

public class Adress : BaseEntity
{
    public string? AdressOne { get; private set; }
    public string? Neighborhood { get; private set; }
    public string? ZipCode { get; private set; }
    public string? City { get; private set; }
    public string? Country { get; private set; }
    public string? State { get; private set; }
    public int? Number { get; private set; }
    public Guid PersonId { get; set; }
    public Bandit Person { get; set; }

    public Adress(Guid personId,string? addressOne, string? neighborhood, string? zipCode, string? country, string? city, string? state, int? number, Guid id) : base(id)
    {
        ValidateDomain(personId,addressOne, neighborhood, zipCode, country, city, state, number);
    }

    public void ValidateDomain(Guid personId, string? addressOne, string? neighborhood, string? zipCode, string? country, string? city, string? state, int? number)
    {
        DomainExceptionValidation.When(addressOne.Length > 100, "O nome da rua só é permitido até cem caracteres");
        DomainExceptionValidation.When(neighborhood.Length > 50, "O nome do bairro só é permitido até 50 caracteres");
        DomainExceptionValidation.When(city.Length > 50, "O nome da cidade só é permitido até 50 caracteres");
        DomainExceptionValidation.When(state.Length > 2, "O nome da UF só é permitido até 2 caracteres");
        DomainExceptionValidation.When(country.Length > 20, "O nome da UF só é permitido até 20 caracteres");
        DomainExceptionValidation.When(zipCode.Length > 9, "O CEP só é permitido até 9 caracteres");
        DomainExceptionValidation.When(personId == Guid.Empty, "É necessário atribuir esse endereço a uma pessoa");
        AdressOne = addressOne;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        Country = country;
        City = city;
        State = state;
        Number = number;
        PersonId = personId;
    }   
}
