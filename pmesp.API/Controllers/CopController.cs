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

    public CopController(
        ICopService copService
    )
    {
        _copService = copService;
    }

    [HttpPost]
    public async Task<ActionResult<CopDTO>> CreateAccountCop([FromBody] CopDTO cop)
    {
        var result =  await _copService.PostAsync(cop);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
    {
        var result = await _copService.LoginAsync(credentials);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
