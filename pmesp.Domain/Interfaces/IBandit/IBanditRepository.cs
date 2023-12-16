using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Base;

namespace pmesp.Domain.Interfaces.Bandits;

public interface IBanditRepository : IRepository<Bandit>
{
    Task<Bandit> GetByName(string name);
    Task<IEnumerable<Bandit>> GetAllInfos();
}
