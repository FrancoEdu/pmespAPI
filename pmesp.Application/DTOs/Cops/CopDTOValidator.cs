using FluentValidation;

namespace pmesp.Application.DTOs.Cops;

public class CopDTOValidator : AbstractValidator<CopDTO>
{
    public CopDTOValidator()
    {
        // NAME
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("É necessário conteúdo no nome do policial")
            .NotNull()
            .WithMessage("O nome do policial é obrigatório no cadastro");

        // EMAIL
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("É necessário conteúdo no Email do policial")
            .NotNull()
            .WithMessage("O email do policial é necessário no cadastro")
            .EmailAddress()
            .WithMessage("O email não está no formato correto");

        // DESCRIPTION
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("A descrição não pode ultrapassar os 255 caracteres");

        // GRADUATION
        RuleFor(x => x.Graduation)
            .NotEmpty()
            .WithMessage("É necessário conteúdo na graduação do policial")
            .NotNull()
            .WithMessage("A graduação do policial é necessário no cadastro")
            .MaximumLength(5)
            .WithMessage("A graduação do policial não pode ultrapassar os 5 caracteres");

        // PASSWORD
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("É necessário conteúdo na senha do policial")
            .NotNull()
            .WithMessage("A senha do policial é necessário no cadastro")
            .MaximumLength(15)
            .WithMessage("A senha do policial não pode ultrapassar os 15 caracteres")
            .MinimumLength(10)
            .WithMessage("A senha do policial não pode ultrapassar os 10 caracteres");
    }
}
