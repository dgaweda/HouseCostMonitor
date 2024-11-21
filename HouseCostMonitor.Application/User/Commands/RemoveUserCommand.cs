namespace HouseCostMonitor.Application.User.Commands;

using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

public record RemoveUserCommand(Guid Id) : IRequest;

public class RemoveUserCommandHandler(IUserStore<User> userStore) : IRequestHandler<RemoveUserCommand>
{
    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        var userId = request.Id.ToString();
        var dbUser = await userStore.FindByIdAsync(userId, cancellationToken);
        if (dbUser is null)
            throw new NotFoundException(nameof(User), userId);

        await userStore.DeleteAsync(dbUser, cancellationToken);
    }
}