using Domain.Users.Errors;
using Microsoft.EntityFrameworkCore;
using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Update;

internal sealed class UpdateUserHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        user.Update(
            firstName: request.FirstName,
            lastName: request.LastName,
            middleName: request.MiddleName,
            login: request.Login,
            email: request.Email);
        
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}