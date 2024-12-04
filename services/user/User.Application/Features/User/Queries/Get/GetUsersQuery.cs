using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Queries.Get;

public sealed record GetUsersQuery() : IQuery<List<Domain.Entities.User>>;