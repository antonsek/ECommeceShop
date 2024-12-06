using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Queries.GetById;

public sealed record GetByIdQuery(Guid id) : IQuery<Domain.Entities.User>;