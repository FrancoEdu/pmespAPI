using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Validations;
using System.Drawing;
using System.Xml.Linq;

namespace pmesp.Domain.Entities.Tattoos;

public class Tattoo
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string BodyLocation { get; private set; }
    public bool Colored { get; private set; }
    public string? Description { get; private set; }
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }

    public Tattoo(string name, string bodyLocation, bool colored, string? description, string banditId)
    {
        Id = Guid.NewGuid().ToString();
        ValidateDomain(name, bodyLocation, colored, description, banditId);
    }

    public void ValidateDomain(string name, string bodyLocation, bool colored, string? description, string banditId)
    {
        DomainExceptionValidation.When(name.Length > 50, "Nome da tatuagem só é permitido até 50 caracteres");
        Name = name;

        DomainExceptionValidation.When(bodyLocation.Length > 30, "Lugar da tatuagem só é permitido até 30 caracteres");
        BodyLocation = bodyLocation;

        DomainExceptionValidation.When(banditId == "", "É necessário passar o ID do bandido que a tatuagem será associada");
        DomainExceptionValidation.When(banditId == null, "É necessário passar o ID do bandido que a tatuagem será associada");
        BanditId = banditId;

        Colored = colored;
        Description = description;
    }
}
