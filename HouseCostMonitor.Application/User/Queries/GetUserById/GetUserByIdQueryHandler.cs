namespace HouseCostMonitor.Application.User.Queries.GetUserById;

using AutoMapper;
using HouseCostMonitor.Application.User.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto?>;

public class GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        return user is null ? null : mapper.Map<UserDto>(user);
    }
}