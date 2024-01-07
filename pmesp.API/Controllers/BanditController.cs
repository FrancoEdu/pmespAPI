using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.SearchDTO;
using pmesp.Application.Interfaces.Bandits;

namespace pmesp.API.Controllers;

[Route("api/bandit")]
[ApiController]
//[Authorize]
public class BanditController : ControllerBase
{
    private readonly IBanditService _banditService;

    public BanditController(IBanditService banditService)
    {
        _banditService = banditService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var result = await _banditService.GetAllAsync();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync(string id)
    {
        var result = await _banditService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteByIdAsync(string id)
    {
        var result = await _banditService.DeleteByIdAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody]BanditDTO banditDTO)
    {
        var result = await _banditService.PostAsync(banditDTO);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("address")]
    public async Task<ActionResult> PostAddressUsingBanditIdAsync([FromBody]BanditAddressDTO banditAddressDTO)
    {
        var result = await _banditService.PostAddressUsingBanditId(banditAddressDTO);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("photo/{id}")]
    public async Task<ActionResult> PostPhotoBandit(string id, [FromForm] UpdateImageBanditDTO updateImageBanditDTO)
    {
        var result = await _banditService.UpdatePhotoPrincipalBanditAsync(id, updateImageBanditDTO);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("search")]
    public async Task<ActionResult> SearchAsync([FromBody] SearchDTO search)
    {
        var result = await _banditService.SearchAsync(search);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
