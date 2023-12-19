﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
