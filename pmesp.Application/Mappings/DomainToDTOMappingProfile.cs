using AutoMapper;
using pmesp.Application.DTOs;
using pmesp.Domain.Entities;

namespace pmesp.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Bandit,BanditDTO>().ReverseMap();
        CreateMap<RG, RGsDTO>().ReverseMap();
    }
}
