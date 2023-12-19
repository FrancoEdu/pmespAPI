﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Response;

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

        [HttpGet("nome/{id}")]
        public async Task<Response<BanditDTO>> GetWithResponse(string id)
        {
            return await _banditService.GetBanditByName(id);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Bandit>> delete(string id)
        {
            var banditDTO = await _banditService.GetById(id);

            if (banditDTO == null)
            {
                return NotFound();
            }
            await _banditService.Delete(id);
            return Ok(banditDTO);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Bandit>> Put(string id, [FromBody] BanditDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id.Length < 0)
            {
                return BadRequest();
            }
            await _banditService.Update(dto);
            return Ok(dto);
        }
    }
}
