using Dapper;
using Shared;
using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Queries.GetById;

internal sealed class GetByIdHandler(IDbConnectionFactory connectionFactory) : IQueryHandler<GetByIdQuery, Domain.Entities.User>
{
    public async Task<Result<Domain.Entities.User>> Handle(GetByIdQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = connectionFactory.Create();
        
        const string sql = $"""
            SELECT 
                id,
                first_name as firstName,
                last_name as lastName,
                middle_name as middleName,
                email,
                login
            FROM Users WHERE id=@id
            """;
        
        var user = await connection.QuerySingleOrDefaultAsync<Domain.Entities.User>(sql, new { request.id });
        
        if (user == null)
            return Result.Failure<Domain.Entities.User>(Error.NotFound("User", "User not found"));
        
        return user;
    }
    
}