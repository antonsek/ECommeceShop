using Mapster;
using MediatR;
using Shared.Result;
using User.Application.Features.User.Commands.Update;
using User.Infrastructure.Helpers;
using UserService.Abstractions;
using UserService.Extensions;

namespace UserService.Controllers.Administration;

internal sealed class UpdateUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users/{{{Id}:guid}}", Handler)
            .WithTags("User")
            .Produces<User.Domain.Entities.User>();
    }

    private static async Task<IResult> Handler(Guid Id,UpdateUserRequest request, ISender sender)
    {
        UpdateUserCommand command = request.Adapt<UpdateUserCommand>()
            with { Id = Id };

        Result result = await sender.Send(command);

        return result.Match(Results.NoContent, ApiResults.Problem);
    }
}