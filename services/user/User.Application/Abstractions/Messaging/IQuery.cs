using MediatR;
using Shared.Result;

namespace User.Application.Abstractions.Messaging;

public interface IQuery<TResponce> : IRequest<Result<TResponce>>;