using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.BanditAddresses;

public class BanditAddress
{
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }
    public string AddressId { get; set; }
    public Address Address { get; set; }

    public BanditAddress(string banditId, string addressId)
    {
        ValidateDomain(banditId, addressId);
    }

    public void ValidateDomain(string banditId, string addressId)
    {
        DomainExceptionValidation.When(banditId.Length <= 0, "É necessário enviar o Id do bandido");
        DomainExceptionValidation.When(addressId.Length <= 0, "É necessário enviar o Id do endereço");
        BanditId = banditId;
        AddressId = addressId;
    }
}
