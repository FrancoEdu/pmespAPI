using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Search;
using pmesp.Domain.Interfaces.Base;

namespace pmesp.Domain.Interfaces.Bandits;

public interface IBanditRepository : IRepository<Bandit>
{
    Task<Bandit> GetByNameAsync(string name);
    Task<Bandit> GetByEmailAsync(string name);
    Task<Bandit> GetByCpfAsync(string cpf);
    Task<String> Base64PrincipalPhoto(Bandit entity);
    Task<ICollection<Bandit>> GetAllInfosAsync();
    Task<Bandit> UpdatePhotoAsync(Bandit bandit, string photoPath, string extension);
    Task<ICollection<Bandit>> SearchAsync(Searchs searchs);
}
