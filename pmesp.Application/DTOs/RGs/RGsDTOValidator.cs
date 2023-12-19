using FluentValidation;
using System;

namespace pmesp.Application.DTOs.RGs;

public class RGsDTOValidator : AbstractValidator<RGsDTO>
{
    public RGsDTOValidator()
    {
        // NUMBER
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("O conteúdo do Número do RG está vazio")
            .NotNull()
            .WithMessage("O conteúdo do Número do RG não pode ser nulo")
            .MaximumLength(13)
            .WithMessage("O número do RG não pode ultrapassar os 13 caracteres");

        // SENDER
        RuleFor(x => x.Sender)
            .MaximumLength(50)
            .WithMessage("O Orgão emissor não pode ultrapassar os 50 caracteres")
            .NotEmpty()
            .WithMessage("O conteúdo do orgão emissor está vazio")
            .NotNull()
            .WithMessage("O conteúdo do orgão emissor não pode ser nulo");

        // UF
        RuleFor(x => x.Uf)
            .MaximumLength(2)
            .WithMessage("Por favor, abrevie o nome da UF")
            .NotEmpty()
            .WithMessage("O conteúdo da UF está vazio")
            .NotNull()
            .WithMessage("O conteúdo da UF não pode ser nulo");

        // SENDER DATE
        RuleFor(x => x.SenderDate)
            .Must(data => data <= DateTime.Now)
            .WithMessage("A data de expedição não pode ser maior que a data atual.")
            .NotEmpty()
            .WithMessage("O conteúdo da data de expedição está vazio")
            .NotNull()
            .WithMessage("O conteúdo da data de expedição não pode ser nulo");

        // BANDIT ID
        RuleFor(x => x.BanditId)
            .NotEmpty()
            .WithMessage("O conteúdo da data de expedição está vazio")
            .NotNull()
            .WithMessage("O conteúdo da data de expedição não pode ser nulo");
    }
}
