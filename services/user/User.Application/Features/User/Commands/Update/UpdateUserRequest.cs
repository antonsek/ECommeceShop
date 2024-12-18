namespace User.Application.Features.User.Commands.Update;

public record UpdateUserRequest
(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    string Login
);