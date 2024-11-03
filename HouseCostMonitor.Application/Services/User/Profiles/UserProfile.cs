using AutoMapper;
using HouseCostMonitor.Application.Services.User.Dtos;

namespace HouseCostMonitor.Application.Services.User.Profiles;

using HouseCostMonitor.Domain.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUsersQuery>();

        CreateMap<CreateUserCommand, User>();
    }
}