namespace User.Application.Features.User.Commands.Create;

public record CreateUserRequest
(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Login
);