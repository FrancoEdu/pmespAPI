using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs;
using pmesp.Application.Interfaces;
using pmesp.Domain.Entities;

namespace pmesp.API.Controllers
{
    [Route("api/bandit")]
    [ApiController]
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BanditDTO banditDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _banditService.Add(banditDTO);

            return new CreatedAtRouteResult("GetBandit",
                new { id = banditDTO.Id }, banditDTO);
        }

        [HttpGet("{id}", Name = "GetBandit")]
        public async Task<ActionResult<Bandit>> Get(string id)
        {
            var banditDTO = await _banditService.GetById(id);

            if (banditDTO == null)
            {
                return NotFound();
            }
            return Ok(banditDTO);
        }
    }
}
