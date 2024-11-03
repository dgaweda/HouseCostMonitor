namespace HouseCostMonitor.Application.User.Queries.GetUsers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.User.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetUsersQuery : IRequest<IEnumerable<UserDto>>;

public class GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository) : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return (await userRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<UserDto>(mapper.ConfigurationProvider);
    }
}