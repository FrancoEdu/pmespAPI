using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.DTOs.Tattoos;

public class TattooDTOValidator : AbstractValidator<TattooDTO>
{
    public TattooDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome da tatuagem está vazio")
            .NotNull()
            .WithMessage("O nome da tatuagem não pode ser nulo")
            .MaximumLength(50)
            .WithMessage("O nome da tatuagem não pode ultrapassar os 50 caracteres");

        // SENDER
        RuleFor(x => x.BodyLocation)
            .MaximumLength(30)
            .WithMessage("O local da tatuagem não pode ultrapassar os 30 caracteres")
            .NotEmpty()
            .WithMessage("O local da tatuagem está vazio")
            .NotNull()
            .WithMessage("O local da tatuagem não pode ser nulo");

        // UF
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("O descrição da tatuagem não pode ultrapassar 255 caracteres");

        // BANDIT ID
        RuleFor(x => x.BanditId)
            .NotEmpty()
            .WithMessage("O ID do bandido está vazio")
            .NotNull()
            .WithMessage("O ID do bandido não pode ser nulo");
    }
}
