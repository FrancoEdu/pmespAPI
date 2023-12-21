using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.DTOs.Bandits;

public  class BanditAddressDTOValidator : AbstractValidator<BanditAddressDTO>
{
    public BanditAddressDTOValidator()
    {
        // NAME
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("É necessário passar o nome da rua para cadastro")
            .MaximumLength(50)
            .WithMessage("O nome da rua não pode ultrapassar os 50 caracteres");

        // NAME
        RuleFor(x => x.BanditId)
            .NotEmpty()
            .WithMessage("É necessário passar o Id do bandido para cadastro")
            .NotNull()
            .WithMessage("O Id do bandido não pode ser nulo");

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

