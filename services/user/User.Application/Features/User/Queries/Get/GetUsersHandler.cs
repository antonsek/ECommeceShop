using Dapper;
using Microsoft.EntityFrameworkCore;
using Shared.Result;
using User.Application.Abstractions;
using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Queries.Get;

internal sealed class GetUsersHandler(IDbConnectionFactory connectionFactory) : IQueryHandler<GetUsersQuery, List<UserResponce>>
{
    public async Task<Result<List<UserResponce>>> Handle(GetUsersQuery request,
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
                            FROM Users
                            """;

         var users = await connection.QueryAsync<Domain.Entities.User>(sql);
         return users.Select(u => new UserResponce
         {
             Id = u.Id,
             FirstName = u.FirstName,
             LastName =  u.LastName,
             MiddleName = u.MiddleName,
             Email = u.Email,
             Login = u.Login
         }).ToList();
    }
    
}