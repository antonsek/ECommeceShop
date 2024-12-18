using MediatR;
using Shared.Result;

namespace User.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponce> : IRequest<Result<TResponce>>;
