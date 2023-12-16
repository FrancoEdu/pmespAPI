using AutoMapper;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Bandits;
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

    public async Task Add(BanditDTO entity)
    {
        var bandit = _mapper.Map<Bandit>(entity);
        await _banditRepository.CreateAsync(bandit);
    }

    public async Task Delete(string id)
    {
        var bandit = _banditRepository.GetByIdAsync(id).Result;
        await _banditRepository.DeleteAsync(bandit);
    }

    public async Task<IEnumerable<BanditDTO>> GetAll()
    {
        var infos = await _banditRepository.GetAllAsync();
        var dto = _mapper.Map<IEnumerable<BanditDTO>>(infos);
        return dto;
    }

    public async Task<BanditDTO> GetBanditAndRGs(string banditId)
    {
        var bandit = await _banditRepository.GetByIdAsync(banditId);
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        return banditDTO;
    }

    public async Task<BanditDTO> GetById(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        return banditDTO;
    }

    public async Task<BanditDTO> GetBanditByName(string id)
    {
        var bandit = await _banditRepository.GetByIdAsync(id);
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        return banditDTO;
    }

    public async Task Update(BanditDTO entity)
    {
        var bandit = _mapper.Map<Bandit>(entity);
        await _banditRepository.UpdateAsync(bandit);
    }
}
