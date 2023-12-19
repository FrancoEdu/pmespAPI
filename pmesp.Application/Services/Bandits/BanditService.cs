using AutoMapper;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Bandits;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Bandits;

public class BanditService : IBanditService
{
    private IBanditRepository _banditRepository;
    private readonly IMapper _mapper;

    public BanditService(IMapper mapper, IBanditRepository banditRepository)
    {
        _mapper = mapper;
        _banditRepository = banditRepository;
    }

    public async Task<ResultService<ICollection<BanditDTO>>> GetAllAsync()
    {
        var infos = await _banditRepository.GetAllAsync();
        var dto = _mapper.Map<ICollection<BanditDTO>>(infos);
        return ResultService.Ok<ICollection<BanditDTO>>(dto, "Lista de bandidos");
    }

    public async Task<ResultService<BanditDTO>> GetByIdAsync(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);
        return bandit == null ?
            ResultService.Fail<BanditDTO>("Falha ao encontrar um bandido com o Id mencionado") :
            ResultService.Ok<BanditDTO>(_mapper.Map<BanditDTO>(bandit), "Bandido encontrado com sucesso");
    }

    public async Task<ResultService<BanditDTO>> DeleteByIdAsync(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);

        if(bandit == null)
        {
            return ResultService.Fail<BanditDTO>("Falha ao encontrar um bandido com o Id mencionado");
        }

        await _banditRepository.DeleteAsync(bandit);
        return ResultService.Ok<BanditDTO>(_mapper.Map<BanditDTO>(bandit), "Bandido excluído com sucesso");
    }

    public async Task<ResultService<BanditDTO>> PostAsync(BanditDTO entity)
    {
        if(entity == null)
        {
            return ResultService.Fail<BanditDTO>("O objeto deve ser enviado...");
        }

        var result = new BanditDTOValidator().Validate(entity);
        if (!result.IsValid)
        {
            return ResultService.RequestError<BanditDTO>("Problema de validade", result);
        }

        var bandit = await _banditRepository.CreateAsync(_mapper.Map<Bandit>(entity));
        return ResultService.Ok<BanditDTO>(_mapper.Map<BanditDTO>(bandit), "Bandido cadastrado com sucesso");
    }
}
