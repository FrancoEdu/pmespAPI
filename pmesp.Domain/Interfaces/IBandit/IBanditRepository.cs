using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Base;

namespace pmesp.Domain.Interfaces.Bandits;

public interface IBanditRepository : IRepository<Bandit>
{
    Task<Bandit> GetByNameAsync(string name);
    Task<Bandit> GetByEmailAsync(string name);
    Task<Bandit> GetByCpfAsync(string cpf);
    Task<IEnumerable<Bandit>> GetAllInfos();
}
