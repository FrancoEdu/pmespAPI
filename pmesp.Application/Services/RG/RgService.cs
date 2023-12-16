using AutoMapper;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.RGs;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Interfaces.Irg;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Services.RGs;

public class RgService : IRgsService
{
    private IRgRepository _rgRepository;
    private readonly IMapper _mapper;

    public RgService(IRgRepository rgRepository, IMapper mapper)
    {
        _mapper = mapper;
        _rgRepository = rgRepository;
    }

    public async Task Add(RGsDTO entity)
    {
        var rg = _mapper.Map<RG>(entity);
        await _rgRepository.CreateAsync(rg);
    }

    public async Task Delete(string id)
    {
        var rg = _rgRepository.GetByIdAsync(id).Result;
        await _rgRepository.DeleteAsync(rg);
    }

    public async Task<IEnumerable<RGsDTO>> GetAll()
    {
        var rgs = await _rgRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RGsDTO>>(rgs);
    }

    public async Task<RGsDTO> GetById(string id)
    {
        var rg = await _rgRepository.GetByIdAsync(id);
        return _mapper.Map<RGsDTO>(rg);
    }

    public async Task Update(RGsDTO entity)
    {
        var rg = _mapper.Map<RG>(entity);
        await _rgRepository.UpdateAsync(rg);
    }
}
