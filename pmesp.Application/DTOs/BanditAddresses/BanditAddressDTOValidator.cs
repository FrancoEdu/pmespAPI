using FluentValidation;
using pmesp.Application.DTOs.Bandits;

namespace pmesp.Application.DTOs.BanditAddresses;

public class BanditAddressDTOValidator : AbstractValidator<BanditAddressesDTO>
{
    public BanditAddressDTOValidator()
    {
        // ADDRESS ID
        RuleFor(x => x.AddressId)
            .NotEmpty()
            .WithMessage("O Id do endereço não pode ser vazio")
            .NotNull()
            .WithMessage("O Id do endereço não pode ser nulo");

        // BANDIT ID
        RuleFor(x => x.BanditId)
            .NotEmpty()
            .WithMessage("O Id do bandido não pode ser vazio")
            .NotNull()
            .WithMessage("O Id do bandido não pode ser nulo");
    }
}
