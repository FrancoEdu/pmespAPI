using AutoMapper;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.AssociateAddress;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.SearchDTO;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Search;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Domain.Interfaces.IAddress;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        return ResultService.Ok<ICollection<BanditDTO>>(dto, "Lista de bandidos", dto.Count());
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
        banditDTO.PrincipalPhoto = await _banditRepository.Base64PrincipalPhoto(bandit);

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

    public async Task<ResultService<BanditDTO>> UpdatePhotoPrincipalBanditAsync(string banditId,UpdateImageBanditDTO photo)
    {
        if(photo == null)
        {
            return ResultService.Fail<BanditDTO>("É necessário envio da foto para arquivar no banco");
        }

        var bandit = await _banditRepository.GetByIdAsync(banditId);
        if (bandit == null)
        {
            return ResultService.Fail<BanditDTO>("É necessário envio do Id do bandido na URL do endpoint");
        }
        var directoryPath = $"C:\\Desenvolvimento\\Pessoal\\dotNet\\Clean_Architecure\\Storage\\{banditId}\\Principal";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var filePath = Path.Combine(directoryPath, photo.Photo.FileName);
        using Stream fileStream = new FileStream(filePath, FileMode.Create);
        photo.Photo.CopyTo(fileStream);

        await _banditRepository.UpdatePhotoAsync(bandit, filePath, Path.GetExtension(filePath));
        return ResultService.Ok<BanditDTO>(_mapper.Map<BanditDTO>(bandit), $"Adicionado ao {bandit.Name} com sucesso");
    }

    public async Task<ResultService<ICollection<BanditDTO>>> SearchAsync(SearchDTO searchDTO)
    {
        var search = _mapper.Map<Searchs>(searchDTO);
        var infos = await _banditRepository.SearchAsync(search);
        var dto = _mapper.Map<ICollection<BanditDTO>>(infos);
        foreach (var item in dto)
        {
            var bandit = _mapper.Map<Bandit>(item);
            if (bandit.PrincipalPhoto != null)
            {
                item.PrincipalPhoto = await _banditRepository.Base64PrincipalPhoto(bandit);
            }
        }
        var total = await _banditRepository.GetAllAsync();
        return ResultService.Ok<ICollection<BanditDTO>>(dto, "Lista de bandidos", total.Count());
    }
}
