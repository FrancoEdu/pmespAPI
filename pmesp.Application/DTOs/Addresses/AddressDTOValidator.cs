using FluentValidation;

namespace pmesp.Application.DTOs.Addresses;

public class AddressDTOValidator : AbstractValidator<AddressDTO>
{
    public AddressDTOValidator()
    {
        // NAME
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("É necessário passar o nome da rua para cadastro")
            .MaximumLength(50)
            .WithMessage("O nome da rua não pode ultrapassar os 50 caracteres");

        // DESCRIPTION
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("A descrição não pode ultrapassar os 255 caracteres");

        // ZIP CODE
        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .NotNull()
            .WithMessage("É necessário passar o CEP da rua para cadastro")
            .MaximumLength(10)
            .WithMessage("O CEP da rua não pode ultrapassar os 10 caracteres");

        // CITY
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("O nome da cidade não pode ser vazio")
            .NotNull()
            .WithMessage("O nome da cidade não pode ser nulo");

        // STATE
        RuleFor(x => x.State)
            .NotEmpty()
            .WithMessage("O nome do Estado não pode ser vazio")
            .NotNull()
            .WithMessage("O nome do Estado não pode ser nulo");

        // COUNTRY
        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("O nome do país não pode ser vazio")
            .NotNull()
            .WithMessage("O nome do país não pode ser nulo");
    }
}
