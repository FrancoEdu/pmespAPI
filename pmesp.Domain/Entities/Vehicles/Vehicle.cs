using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Validations;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace pmesp.Domain.Entities.Vehicles;

public class Vehicle
{
    public string Id { get; set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Plate { get; private set; }
    public string? Description { get; private set; }
    public string CPFowner { get; private set; }
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }

    public Vehicle(string id, string brand, string model, string color, string plate, string? description, string cPFowner)
    {
        Id = id;
        validateDomain(brand, model, color, plate, description, cPFowner);
    }

    public void validateDomain(string brand, string model, string color, string plate, string? description, string cPFowner)
    {
        DomainExceptionValidation.When(model.Length > 30, "O modelo não pode ultrapassar os 30 caracteres");
        DomainExceptionValidation.When(cPFowner.Length > 14, "O CPF não pode ultrapssar caracteres");
        DomainExceptionValidation.When(brand.Length > 12, "A marca não pode ultrapassar os 12 caracteres");
        DomainExceptionValidation.When(plate.Length > 12, "A placa não pode ultrapassar os 12 caracteres");
        if (description != null)
        {
            DomainExceptionValidation.When(description.Length > 255, "A descrição não pode ultrapassar os 255 caracteres");
        }

        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Description = description;
        CPFowner = cPFowner;
    }
}
