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
        public async Task<ActionResult<IEnumerable<BanditDTO>>> Get()
        {
            try
            {
                var bandits = await _banditService.GetAll();
                return Ok(bandits);
            }
            catch
            {
                throw;
            }
        }
    }
}
