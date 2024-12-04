using Microsoft.EntityFrameworkCore;
using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Queries.Get;

internal sealed class GetUsersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetUsersQuery, List<Domain.Entities.User>>
{
    public async Task<Result<List<Domain.Entities.User>>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .ToListAsync(cancellationToken);

        return users;
    }
    
}