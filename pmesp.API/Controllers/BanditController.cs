using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;

namespace pmesp.API.Controllers
{
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
    }
}
