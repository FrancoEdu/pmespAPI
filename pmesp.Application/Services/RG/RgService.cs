using AutoMapper;
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
        return ResultService.Ok<ICollection<RGsDTO>>(rgDtos);
    }
}
