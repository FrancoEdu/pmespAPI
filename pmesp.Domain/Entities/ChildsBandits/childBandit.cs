using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Childs;

namespace pmesp.Domain.Entities.ChildsBandits;

public class ChildBandit
{
    public string BanditsId { get; private set; }
    public Bandit Bandit { get; private set; }
    public string ChildId { get; private set; }
    public Child Child { get; private set; }
}
