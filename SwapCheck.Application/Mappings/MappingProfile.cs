using AutoMapper;
using SwapCheck.Domain.Entities;
using SwapCheck.Application.DTOs;

namespace SwapCheck.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<Engine, EngineDto>();
        CreateMap<SwapCompatibility, SwapCompatibilityDto>()
            .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => src.Engine));
    }
}