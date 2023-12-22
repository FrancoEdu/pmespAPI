using AutoMapper;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.DTOs.Tattoos;
using pmesp.Application.Interfaces.Tattoos;
using pmesp.Domain.Entities.Tattoos;
using pmesp.Domain.Interfaces;
using pmesp.Domain.Interfaces.Bandits;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Tattoos;

public class TattooService : ITattooService
{
    private readonly IBanditRepository _banditRepository;
    private readonly ITattooRepository _repository;
    private IMapper _mapper;

    public TattooService(IBanditRepository banditRepository, ITattooRepository repository, IMapper mapper)
    {
        _banditRepository = banditRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultService<TattooDTO>> PostAsync(TattooDTO dto)
    {
        if(dto == null)
        {
            return ResultService.Fail<TattooDTO>("O objeto não pode ser nulo");
        }

        var result = new TattooDTOValidator().Validate(dto);
        if(!result.IsValid) 
        {
            return ResultService.RequestError<TattooDTO>("Dados inválidos", result);
        }

        var existsBandiIfCurrentId = await _banditRepository.GetByIdAsync(dto.BanditId);
        if (existsBandiIfCurrentId == null)
        {
            return ResultService.Fail<TattooDTO>("Não existe bandido com o Id atribuído");
        }

        var data = await _repository.PostAsync(_mapper.Map<Tattoo>(dto));
        return ResultService.Ok<TattooDTO>(_mapper.Map<TattooDTO>(data), "Tattoo criada com sucesso");
    }
}
