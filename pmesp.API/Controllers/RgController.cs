using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.RGs;

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
        public async Task<ActionResult> PostAsync([FromBody] RGsDTO rgDto)
        {
            var result = await _rgsService.PostAsync(rgDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var result = await _rgsService.GetByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _rgsService.GetAllAsync();
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _rgsService.DeleteByIdAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
