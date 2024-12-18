namespace User.Application.Features.User.Queries.Get;

public sealed record UserResponce
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Email { get; init; }
    public string Login { get; init; }
}