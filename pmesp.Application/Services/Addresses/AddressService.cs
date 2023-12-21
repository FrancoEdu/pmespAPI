﻿using AutoMapper;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.BanditAddresses;
using pmesp.Application.Interfaces.Addresses;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.BanditAddresses;
using pmesp.Domain.Interfaces.IAddress;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Addresses;

public class AddressService : IAddressesService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<AddressDTO>> PostAsync(AddressDTO entity)
    {
        if (entity == null)
        {
            ResultService.Fail<AddressDTO>("O objeto está vindo nulo");
        }

        var result = new AddressDTOValidator().Validate(entity);
        if (!result.IsValid)
        {
            ResultService.RequestError<AddressDTO>("Erros de validação", result);
        }

        var dto = _mapper.Map<Address>(entity);
        await _addressRepository.CreateAsync(dto);
        return ResultService.Ok<AddressDTO>(_mapper.Map<AddressDTO>(dto), "Criado com sucesso");
    }
}
