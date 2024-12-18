using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Create;

public sealed record CreateUserCommand
(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Login
) : ICommand<Guid>;