using MediatR;
using Shared.Result;
using User.Application.Features.User.Queries.Get;
using User.Application.Features.User.Queries.GetById;
using User.Infrastructure.Helpers;
using UserService.Abstractions;
using UserService.Extensions;

namespace UserService.Controllers.Administration;

internal sealed class GetUserId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/users/{id}", Handler)
            .WithTags("User")
            .Produces<User.Domain.Entities.User>();
    }

    private static async Task<IResult> Handler(Guid id, ISender sender, CancellationToken ct)
    {
        var query = new GetByIdQuery(id);

        Result<UserResponce> result = await sender.Send(query, ct);

        return result.Match(Results.Ok, ApiResults.Problem);
    }
}