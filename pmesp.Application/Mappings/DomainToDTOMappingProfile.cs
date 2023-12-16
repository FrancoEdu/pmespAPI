using AutoMapper;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.RGs;
using pmesp.Domain.Entities.Bandits;
using pmesp.Domain.Entities.RGs;

namespace pmesp.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Bandit,BanditDTO>().ReverseMap();
        CreateMap<RG, RGsDTO>().ReverseMap();
    }
}
