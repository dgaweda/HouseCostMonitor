namespace HouseCostMonitor.Application.House.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.House.Dtos;
using HouseCostMonitor.Domain.Entities;

public class HouseProfile : Profile
{
    public HouseProfile()
    {
        CreateMap<House, HouseDto>()
            .ForPath(dest => dest.ToDo, opt => opt.MapFrom(src => src.Jobs));
    }
}