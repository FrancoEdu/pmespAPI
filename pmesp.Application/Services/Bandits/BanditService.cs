﻿using AutoMapper;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.Response;
using pmesp.Domain.Interfaces.Bandits;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Bandits;

public class BanditService : IBanditService
{
    private IBanditRepository _banditRepository;
    private readonly IMapper _mapper;
    private Response<BanditDTO> _response;

    public BanditService(IMapper mapper, IBanditRepository banditRepository)
    {
        _mapper = mapper;
        _banditRepository = banditRepository;
        _response = new Response<BanditDTO>();
    }

    public async Task<Response<BanditDTO>> Add(BanditDTO entity)
    {
        var exists = await _banditRepository.GetByCpfAsync(entity.CPF);
        if (exists != null)
        {
            _response.setResponse(null, "Já existe um Bandido cadastrado com esse CPF...", false, 400);
            return _response;
        }
        var existsEmail = await _banditRepository.GetByEmailAsync(entity.Email);
        if (existsEmail != null)
        {
            _response.setResponse(null, "Já existe um Bandido cadastrado com esse Email...", false, 400);
            return _response;
        }

        var bandit = _mapper.Map<Bandit>(entity);
        await _banditRepository.CreateAsync(bandit);
        _response.setResponse(entity, "Bandido cadastrado!", true, 201);
        return _response;
    }

    public async Task Delete(string id)
    {
        var bandit = _banditRepository.GetByIdAsync(id).Result;
        await _banditRepository.DeleteAsync(bandit);
    }

    public async Task<Response<IEnumerable<BanditDTO>>> GetAll()
    {
        var infos = await _banditRepository.GetAllAsync();
        var dto = _mapper.Map<IEnumerable<BanditDTO>>(infos);
        return dto;
    }

    public async Task<Response<BanditDTO>> GetBanditAndRGs(string banditId)
    {
        var bandit = await _banditRepository.GetByIdAsync(banditId);
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        return banditDTO;
    }

    public async Task<Response<BanditDTO>> GetById(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        return banditDTO;
    }

    public async Task<Response<BanditDTO>> GetBanditByName(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);
        if (bandit == null)
        {
            _response.setResponse(null, "Não encontramos nenhum bandido com esse identificador...", false, 400);
            return _response;
        }
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        _response.setResponse(banditDTO, "Encontramos o bandido com esse identificador", true, 200);
        return _response;
    }

    public async Task<Response<BanditDTO>> Update(BanditDTO entity)
    {
        var bandit = _mapper.Map<Bandit>(entity);
        await _banditRepository.UpdateAsync(bandit);
    }
}
