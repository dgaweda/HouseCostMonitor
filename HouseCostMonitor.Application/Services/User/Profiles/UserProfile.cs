using AutoMapper;

namespace HouseCostMonitor.Application.Services.User.Profiles;

using HouseCostMonitor.Application.Services.User.Commands.CreateUser;
using HouseCostMonitor.Application.Services.User.Queries;
using HouseCostMonitor.Domain.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUsersQuery>();

        CreateMap<CreateUserCommand, User>();
    }
}