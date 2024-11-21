namespace HouseCostMonitor.Application.User.Commands;

using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

public record UpdateUserRoleCommand(Guid? UserId, string? Email, RoleType RoleType) : IRequest;

public class UpdateUserRoleCommandHandler(
    IUserStore<User> userStore, 
    IRoleStore<Role> roleStore, 
    IUserRoleStore<User> userRoleStore) : IRequestHandler<UpdateUserRoleCommand>
{
    public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        User? dbUser = null;
        if (request.UserId is not null)
            dbUser = await userStore.FindByIdAsync(request.UserId.ToString()!, cancellationToken);
        else if (request.Email is not null)
            dbUser = await userStore.FindByNameAsync(request.Email.ToUpper(), cancellationToken);
        
        if (dbUser is null)
            throw new NotFoundException(nameof(User));

        var role = await roleStore.FindByNameAsync(request.RoleType.ToString(), cancellationToken);
        if (role is null)
            throw new NotFoundException(nameof(Role), request.RoleType.ToString());

        await userRoleStore.AddToRoleAsync(dbUser, role.Name!, cancellationToken);
    }
}