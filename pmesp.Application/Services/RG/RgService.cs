using AutoMapper;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.Interfaces.RGs;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Domain.Interfaces.Irg;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Services.RGs;

public class RgService : IRgsService
{
    private IRgRepository _rgRepository;
    private IBanditRepository _banditRepository;

    private readonly IMapper _mapper;

    public RgService(IRgRepository rgRepository, IBanditRepository banditRepository,IMapper mapper)
    {
        _mapper = mapper;
        _rgRepository = rgRepository;
        _banditRepository = banditRepository;
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

    public async Task<ResultService<RGsDTO>> PostAsync(RGsDTO entity)
    {
        if(entity == null)
        {
            return ResultService.Fail<RGsDTO>("O corpo da requisição está vazio");
        }

        var result = new RGsDTOValidator().Validate(entity);
        if (!result.IsValid)
        {
            return ResultService.RequestError<RGsDTO>("Corpo da requisição com informações inválidas", result);
        }

        var existsBandiIfCurrentId = await _banditRepository.GetByIdAsync(entity.BanditId);
        if(existsBandiIfCurrentId == null)
        {
            return ResultService.Fail<RGsDTO>("Não existe bandido com o Id atribuído");
        }

        var rg = _mapper.Map<RG>(entity);
        var data = await _rgRepository.CreateAsync(rg);
        return ResultService.Ok<RGsDTO>(_mapper.Map<RGsDTO>(rg), $"RG adicionado ao bandido {existsBandiIfCurrentId.Surname} com sucesso");
    }
}
