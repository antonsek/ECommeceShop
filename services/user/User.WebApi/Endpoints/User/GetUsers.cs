using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Result;
using User.Application.Features.User.Queries.Get;
using User.Infrastructure;
using UserService.Abstractions;

namespace UserService.Controllers.Administration;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/users", Handler)
            .WithTags("User")
            .Produces<List<User.Domain.Entities.User>>();
    }

    private static async Task<IResult> Handler(ISender sender, CancellationToken ct)
    {
        var query = new GetUsersQuery();
        
        Result<List<UserResponce>> users = await sender.Send(query, ct);
        
        return Results.Ok(users);
    }
}