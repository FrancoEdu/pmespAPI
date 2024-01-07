using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.Guns;

public class Gun
{
    public string Id { get; set; }
    public string? Brand { get; private set; }
    public string Model { get; private set; }
    public string Caliber { get; private set; }
    public string? National { get; private set; }
    public string? Numeration { get; private set; }
    public bool? Shaved { get; private set; }
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }

    public Gun(string id, string? brand, string model, string caliber, string? national, string? numeration, bool? shaved)
    {
        Id = id;
        validateDomain(brand, model, caliber, national, numeration, shaved);
    }

    public void validateDomain(string? brand, string model, string caliber, string? national, string? numeration, bool? shaved)
    {
        DomainExceptionValidation.When(model.Length > 30, "O modelo não pode ultrapassar os 30 caracteres");
        DomainExceptionValidation.When(brand.Length > 12, "A marca não pode ultrapassar os 12 caracteres");
        DomainExceptionValidation.When(caliber.Length > 5, "O calibre não pode ultrapssar 5 caracteres");
        DomainExceptionValidation.When(numeration.Length > 15, "A numeração não pode ultrapassar os 15 caracteres");
        Brand = brand;
        Model = model;
        Caliber = caliber;
        National = national;
        Numeration = numeration;
        Shaved = shaved;
    }
}
