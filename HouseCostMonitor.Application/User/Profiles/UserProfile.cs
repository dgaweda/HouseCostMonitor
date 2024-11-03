namespace HouseCostMonitor.Application.User.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.User.Commands.CreateUser;
using HouseCostMonitor.Application.User.Dtos;
using HouseCostMonitor.Domain.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<CreateUserCommand, User>();
    }
}