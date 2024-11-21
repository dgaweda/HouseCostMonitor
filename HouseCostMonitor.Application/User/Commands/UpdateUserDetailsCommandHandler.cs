namespace HouseCostMonitor.Application.User.Commands;

using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

public record UpdateUserDetailsCommand(string Firstname, string Lastname, DateOnly DateOfBirth) : IRequest;

public class UpdateUserDetailsCommandHandler(IUserContext userContext, IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);
        if (dbUser is null)
            throw new NotFoundException(nameof(User), user.Id);

        dbUser.Firstname = request.Firstname;
        dbUser.Lastname = request.Lastname;
        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}