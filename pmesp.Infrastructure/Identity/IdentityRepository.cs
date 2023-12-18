using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.Cops.Account;
using pmesp.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace pmesp.Infrastructure.Identity;

public class IdentityRepository : IAuthenticate
{
    private readonly ApplicationDbContext _context;
    private IConfiguration _configuration;

    public IdentityRepository(ApplicationDbContext context, IConfiguration configuration)
    {
         _context = context;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string pwd)
    {
        var cop = await _context.
            Cops.
            AsNoTracking().
            FirstOrDefaultAsync(x => 
                x.Email.
                ToLower().
                Equals(email.ToLower()));

        if(cop == null )
        {
            return false;
        }

        using var hmac = new HMACSHA512(cop.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pwd));
        for(int x = 0; x < computedHash.Length; x++)
        {
            if (computedHash[x] != cop.PasswordHash[x]) return false;
        }

        return true;

    }

    public string GenerateToken(string id, string email)
    {
        var claims = new[]
        {
            new Claim("id", id),
            new Claim("email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jwt:secretKey"]
            ));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(60);

        JwtSecurityToken token = new JwtSecurityToken
        (
            issuer: _configuration["Jwt:issuer"],
            audience: _configuration["Jwt:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Cop> GetCopByEmail(string email)
    {
        return await _context.
                Cops.
                AsNoTracking().
                FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> UserExists(string email)
    {
        var cop = await _context.
            Cops.
            AsNoTracking().
            FirstOrDefaultAsync(x =>
                x.Email.
                ToLower().
                Equals(email.ToLower()));

        return cop == null ? false : true;
    }
}
