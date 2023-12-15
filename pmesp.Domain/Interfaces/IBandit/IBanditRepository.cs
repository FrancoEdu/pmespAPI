using pmesp.Domain.Entities;
using pmesp.Domain.Interfaces.Base;

namespace pmesp.Domain.Interfaces.Bandits;

public interface IBanditRepository : IRepository<Bandit>
{
    Task<IEnumerable<Bandit>> GetAllInfos();
}
