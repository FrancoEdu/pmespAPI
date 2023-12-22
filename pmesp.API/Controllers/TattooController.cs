using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Tattoos;
using pmesp.Application.Interfaces.Tattoos;

namespace pmesp.API.Controllers
{
    [Route("api/tattoo")]
    [ApiController]
    public class TattooController : ControllerBase
    {
        private readonly ITattooService _service;

        public TattooController(ITattooService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TattooDTO tattoo)
        {
            var result = await _service.PostAsync(tattoo);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
