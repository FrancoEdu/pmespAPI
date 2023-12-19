using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.RGs;
using pmesp.Domain.Entities.RGs;

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

        /*
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
        public async Task<ActionResult<RG>> Get(string id)
        {
            var rg = await _rgsService.GetById(id);

            if (rg == null)
            {
                return NotFound();
            }
            return Ok(rg);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RG>> Delete(string id)
        {
            var rg = await _rgsService.GetById(id);
            if(rg == null)
            {
                return NotFound("Nenhum RG encontrado com esse id");
            }

            await _rgsService.Delete(id);
            return Ok(rg);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RG>> Put(string id, [FromBody]RGsDTO rg)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id.Length < 0)
            {
                return BadRequest("Necessário o envio do token para validarmos");
            }

            await _rgsService.Update(rg);
            return Ok(rg);
        }
        */
    }
}
