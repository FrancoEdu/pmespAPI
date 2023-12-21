using AutoMapper;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.BanditAddresses;
using pmesp.Application.Interfaces.Addresses;
using pmesp.Application.Interfaces.BanditAddresses;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.BanditAddresses;
using pmesp.Domain.Interfaces.IBanditAddresses;
using System.Threading.Tasks;

namespace pmesp.Application.Services.BanditAddresses;

public class BanditAddressService : IBanditAddressService
{
    private readonly IAddressesService _addressesService;
    private readonly IBanditService _banditService;
    private readonly IBanditAddressesRepository _repository;
    private readonly IMapper _mapper;

    public BanditAddressService(IAddressesService addressesService,IBanditService banditService,IBanditAddressesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _banditService = banditService;
        _addressesService = addressesService;
    }

    public async Task<ResultService<BanditAddressesDTO>> PostAsync(BanditAddressesDTO entity)
    {
        if (entity == null)
        {
            ResultService.Fail<BanditAddressesDTO>("O objeto está vindo nulo");
        }

        var result = new BanditAddressDTOValidator().Validate(entity);
        if (!result.IsValid)
        {
            ResultService.RequestError<BanditAddressesDTO>("Erros de validação", result);
        }

        var existsBandit = await _banditService.GetByIdAsync(entity.BanditId);
        if (existsBandit == null)
        {
            ResultService.Fail<BanditAddressesDTO>("Não existe bandido com o Id mencionado");
        }

        // TODO

        // if (existsAddress == null)
        // {
        //    ResultService.Fail<BanditAddressesDTO>("Não existe bandido com o Id mencionado");
        // }

        var dto = _mapper.Map<BanditAddress>(entity);
        await _repository.CreateAsync(dto);
        return ResultService.Ok<BanditAddressesDTO>(_mapper.Map<BanditAddressesDTO>(dto), "Associado com sucesso");
    }
}
