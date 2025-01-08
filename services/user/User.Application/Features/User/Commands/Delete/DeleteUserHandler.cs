using Domain.Users.Errors;
using Microsoft.EntityFrameworkCore;
using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Delete;

internal sealed class DeleteUserHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}