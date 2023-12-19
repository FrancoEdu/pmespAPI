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
        return ResultService.Ok<ICollection<BanditDTO>>(dto);
    }
}
