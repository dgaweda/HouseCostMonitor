namespace HouseCostMonitor.Application.User.Commands.CreateUser;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record CreateUserCommand : IRequest<Guid>
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}

public class CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        var id = await userRepository.AddAsync(user, cancellationToken);
        return id;
    }
}