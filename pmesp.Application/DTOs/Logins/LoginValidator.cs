using FluentValidation;
using pmesp.API.Models.Logins;

namespace pmesp.Application.DTOs.Logins;

public class LoginValidator : AbstractValidator<LoginDTO>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email enviado não pode ser vazio")
            .NotNull()
            .WithMessage("O email não pode ser nulo")
            .EmailAddress()
            .WithMessage("O email enviado não está nos padrões de email: xxxx@xxxx.com");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("A senha enviada não pode ser vazia")
            .NotNull()
            .WithMessage("A senha não pode ser nula");
    }
}
