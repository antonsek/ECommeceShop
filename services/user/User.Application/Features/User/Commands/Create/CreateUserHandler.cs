using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Create;

internal sealed class CreateUserHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = Domain.Entities.User.Create(
            firstName: request.FirstName,
            lastName: request.LastName,
            middleName: request.MiddleName,
            login: request.Login,
            email: request.Email);
        
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}