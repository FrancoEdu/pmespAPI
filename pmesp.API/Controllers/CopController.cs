using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using pmesp.API.Models.Logins;
using pmesp.API.Models.Tokens;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.Interfaces.Cop;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.Cops.Account;

namespace pmesp.API.Controllers;

[Route("api/cop")]
[ApiController]
public class CopController : ControllerBase
{
    private readonly ICopService _copService;
    private readonly IAuthenticate _authenticateService;

    public CopController(
        ICopService copService,
        IAuthenticate authenticateService
    )
    {
        _copService = copService;
        _authenticateService = authenticateService;
    }

    [HttpPost]
    public async Task<ActionResult<TokenDTO>> CreateAccountCop([FromBody] CopDTO cop)
    {
        var result =  await _copService.PostAsync(cop);
        
        if(result.Success)
        {
            var token = _authenticateService.GenerateToken(cop.Id, cop.Email);
            return new TokenDTO
            {
                TokenJWT = token,
            };
        }

        return BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
    {
        var result = await _copService.LoginAsync(credentials);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
