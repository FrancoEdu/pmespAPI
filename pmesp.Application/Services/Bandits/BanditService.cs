using AutoMapper;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.AssociateAddress;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Domain.Interfaces.IAddress;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Bandits;

public class BanditService : IBanditService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IBanditRepository _banditRepository;
    private readonly IMapper _mapper;

    public BanditService(IMapper mapper, IBanditRepository banditRepository, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _banditRepository = banditRepository;
        _addressRepository = addressRepository;
    }

    public async Task<ResultService<ICollection<BanditDTO>>> GetAllAsync()
    {
        var infos = await _banditRepository.GetAllAsync();
        var dto = _mapper.Map<ICollection<BanditDTO>>(infos);
        return ResultService.Ok<ICollection<BanditDTO>>(dto, "Lista de bandidos");
    }

    public async Task<ResultService<BanditDTO>> GetByIdAsync(string id)
    {
        if(id == null)
        {
            ResultService.Fail<BanditDTO>("Envie o Id do Bandido");
        }

        var bandit = await _banditRepository.GetByIdAsync(id);
        if(bandit == null)
        {
            ResultService.Fail<BanditDTO>("Falha ao encontrar um bandido com o Id mencionado");
        }
        var banditDTO = _mapper.Map<BanditDTO>(bandit);
        banditDTO.Addresses = _mapper.Map<ICollection<AddressDTO>>(await _addressRepository.GetAddressesByBanditIdAsync(id));

        return ResultService.Ok<BanditDTO>(banditDTO, "Bandido encontrado com sucesso");
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

    public async Task<ResultService<BanditDTO>> PostAddressUsingBanditId(BanditAddressDTO banditAddressDTO)
    {
        if(banditAddressDTO == null)
        {
            return ResultService.Fail<BanditDTO>("Não recebemos nenhum objeto, valide o envio");
        }

        var userBanditExists = await _banditRepository.GetByIdAsync(banditAddressDTO.BanditId);
        if(userBanditExists == null)
        {
            return ResultService.Fail<BanditDTO>("Não existe o bandido informado...");
        }

        var result = new BanditAddressDTOValidator().Validate(banditAddressDTO);
        if (!result.IsValid)
        {
            return ResultService.RequestError<BanditDTO>("Problema de validade", result);
        }

        var addressDTO = _mapper.Map<Address>(_mapper.Map<AddressDTO>(banditAddressDTO));
        await _addressRepository.CreateAsync(addressDTO);
        var associate = _mapper.Map<AssociateAddresses>
            (new AssociateAddressDTO()
            {
                AddressesId = addressDTO.Id,
                BanditsId = userBanditExists.Id
            }
            ) ;

        await _addressRepository.PostAddressUsingBanditIdAsync(associate);
        return ResultService.Ok<BanditDTO>(_mapper.Map<BanditDTO>(userBanditExists), "Cadastrado com sucesso!");
    }
}
