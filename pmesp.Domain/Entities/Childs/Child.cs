using pmesp.Domain.Entities.ChildsBandits;
using pmesp.Domain.Entities.People;
using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities.Childs;

public class Child : Person
{
    public string? SchoolPeriod { get; private set; }
    public ICollection<ChildBandit> Bandits { get; private set; }
    public Child(string id, string name, string cPF, string? schoolPeriod) 
        : base(id, name, cPF)
    {
        Bandits = new List<ChildBandit>();
        validateDomain(name, cPF, schoolPeriod);
    }

    public void validateDomain(string name, string cPF, string? schoolPeriod)
    {
        SchoolPeriod = schoolPeriod;
    }
}
