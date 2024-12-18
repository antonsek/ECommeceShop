using Mapster;
using MediatR;
using Shared.Result;
using User.Application.Features.User.Commands.Create;
using User.Infrastructure.Helpers;
using UserService.Abstractions;
using UserService.Extensions;

namespace UserService.Controllers.Administration;

internal sealed class CreateUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users/", Handler)
            .WithTags("User")
            .Produces<User.Domain.Entities.User>();
    }

    private static async Task<IResult> Handler(CreateUserRequest request, ISender sender)
    {
        CreateUserCommand command = request.Adapt<CreateUserCommand>();

        Result<Guid> result = await sender.Send(command);

        return result.Match(Results.Ok, ApiResults.Problem);
    }
}