using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.RGs;
using pmesp.Application.Services;
using pmesp.Domain.Entities;

namespace pmesp.API.Controllers
{
    [Route("api/rg")]
    [ApiController]
    public class RgController : ControllerBase
    {
        private readonly IRgsService _rgsService;

        public RgController(IRgsService rgsService)
        {
            _rgsService = rgsService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RGsDTO rgDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _rgsService.Add(rgDto);

            return new CreatedAtRouteResult("GetRG",
                new { id = rgDto.Id }, rgDto);
        }

        [HttpGet("{id}", Name = "GetRG")]
        public async Task<ActionResult<RGsDTO>> Get(string id)
        {
            var rg = await _rgsService.GetById(id);

            if (rg == null)
            {
                return NotFound();
            }
            return Ok(rg);
        }
    }
}
