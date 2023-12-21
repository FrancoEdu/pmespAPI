using pmesp.API.Models.Logins;
using pmesp.API.Models.Tokens;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.Interfaces.Base;
using pmesp.Application.Services;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Cop;

public interface ICopService : IBaseService<CopDTO>
{
    Task<ResultService<TokenDTO>> LoginAsync(LoginDTO credentials);
    Task<ResultService<LoginDTO>> ValidateCopLogin(LoginDTO credentials);
}
