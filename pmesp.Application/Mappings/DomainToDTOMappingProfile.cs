using AutoMapper;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.AssociateAddress;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.DTOs.Tattoos;
using pmesp.Domain.Entities.Addresses;
using pmesp.Domain.Entities.AssociateAddress;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.RGs;
using pmesp.Domain.Entities.Tattoos;

namespace pmesp.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Bandit,BanditDTO>().ReverseMap();
        CreateMap<RG, RGsDTO>().ReverseMap();
        CreateMap<Cop, CopDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<Address, BanditAddressDTO>().ReverseMap();
        CreateMap<AddressDTO, BanditAddressDTO>().ReverseMap();
        CreateMap<AssociateAddresses,AssociateAddressDTO>().ReverseMap();
        CreateMap<Tattoo, TattooDTO>().ReverseMap();
    }
}
