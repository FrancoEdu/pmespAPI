using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Domain.Entities.Cops.Account;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string senha);
    Task<bool> UserExists(string email);
    public string GenerateToken(string id, string email);
    Task<Cop> GetCopByEmail(string email);
}
