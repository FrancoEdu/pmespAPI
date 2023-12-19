using AutoMapper;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.Base;
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

    public async Task<ResultService<ICollection<RGsDTO>>> GetAllAsync()
    {
        var rgs = await _rgRepository.GetAllAsync();
        var rgDtos = _mapper.Map<ICollection<RGsDTO>>(rgs);
        return ResultService.Ok<ICollection<RGsDTO>>(rgDtos, "Lista de RGs");
    }

    public async Task<ResultService<RGsDTO>> GetByIdAsync(string id)
    {
        var rg = await _rgRepository.GetByIdAsync(id);
        return rg == null ?
            ResultService.Fail<RGsDTO>("Não encontramos nenhum RG com esse número") :
            ResultService.Ok<RGsDTO>(_mapper.Map<RGsDTO>(rg), "RG encontrado");  
    }

    public async Task<ResultService<RGsDTO>> DeleteByIdAsync(string id)
    {
        var rg = await _rgRepository.GetByIdAsync(id);

        if (rg == null)
        {
            return ResultService.Fail<RGsDTO>("Falha ao encontrar um RG com o Id mencionado");
        }

        await _rgRepository.DeleteAsync(rg);
        return ResultService.Ok<RGsDTO>(_mapper.Map<RGsDTO>(rg), "RG excluído");
    }

    public Task<ResultService<RGsDTO>> PostAsync(RGsDTO entity)
    {
        throw new System.NotImplementedException();
    }
}
