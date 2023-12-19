using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using pmesp.API.Models.Logins;
using pmesp.API.Models.Tokens;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.Interfaces.Cop;
using pmesp.Domain.Entities.Bandits;
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

    /*
    [HttpPost]
    public async Task<ActionResult<Token>> CreateAccountCop([FromBody] CopDTO cop)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var emailExists = await _authenticateService.UserExists(cop.Email);

        if(emailExists == false)
        {
            await _copService.Add(cop);
            var token = _authenticateService.GenerateToken(cop.Id, cop.Email);
            return new Token { 
                TokenJWT = token,
            };
        }

        return BadRequest("O Email já existe atribuído a outro policial..");
    }

    [HttpPost("login")]
    public async Task<ActionResult<Token>> Login(Login credentials)
    {
        var exists = await _authenticateService.UserExists(credentials.Email);

        if(!exists)
        {
            return Unauthorized("Conta com o email informado não existe...");
        }

        var result = await _authenticateService.AuthenticateAsync(credentials.Email, credentials.Password);
        if (!result)
        {
            return BadRequest("Usuário ou senha inválidos");
        }

        var cop = await _authenticateService.GetCopByEmail(credentials.Email);
        var token = _authenticateService.GenerateToken(cop.Id, credentials.Email);
        return new Token
        {
            TokenJWT = token,
        };
    }
    */
}
