using MediatR;
using Shared.Result;
using User.Application.Features.User.Commands.Delete;
using User.Infrastructure.Helpers;
using UserService.Abstractions;
using UserService.Extensions;

namespace UserService.Controllers.Administration;

internal sealed class DeleteUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/users/{{{Id}:guid}}", Handler)
            .WithTags("User")
            .Produces<User.Domain.Entities.User>();
    }

    private static async Task<IResult> Handler(Guid Id, ISender sender)
    {
        var command = new DeleteUserCommand(Id);

        Result result = await sender.Send(command);

        return result.Match(Results.NoContent, ApiResults.Problem);
    }
}