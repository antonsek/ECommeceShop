using User.Application.Abstractions.Messaging;
using User.Application.Features.User.Queries.Get;

namespace User.Application.Features.User.Queries.GetById;

public sealed record GetByIdQuery(Guid id) : IQuery<UserResponce>;