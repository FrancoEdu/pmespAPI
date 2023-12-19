using FluentValidation;

namespace pmesp.Application.DTOs.Bandits;

public class BanditDTOValidator : AbstractValidator<BanditDTO>
{
    public BanditDTOValidator()
    {
        // NAME
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("É necessário passar o nome para cadastro")
            .MaximumLength(30)
            .WithMessage("O nome não pode ultrapassar os 30 caracteres");

        // DESCRIPTION
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("A descrição não pode ultrapassar os 255 caracteres");

        // CPF
        RuleFor(x => x.CPF)
           .NotEmpty()
           .NotNull()
           .WithMessage("É necessário passar o CPF para cadastro")
           .MaximumLength(14)
           .WithMessage("O CPF não pode ultrapassar os 14 caracteres");

        // PHONE
        RuleFor(x => x.Phone)
           .MaximumLength(12)
           .WithMessage("O Telefone não pode ultrapassar os 12 caracteres");

        // EMAIL
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("O email não tem o formato correto");
    }
}
