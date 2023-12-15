using pmesp.Domain.Entities.Common;

namespace pmesp.Domain.Entities;

public class Bandit : Person
{
    public ICollection<Person> Childrens { get; set;}
    public ICollection<RG> RGs { get; set;}
    public ICollection<Adress> Adresses { get; set;}
}
