using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Update;

public sealed record UpdateUserCommand
(
    Guid Id,
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Login
) : ICommand;