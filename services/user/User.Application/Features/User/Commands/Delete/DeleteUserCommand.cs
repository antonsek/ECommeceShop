using User.Application.Abstractions.Messaging;

namespace User.Application.Features.User.Commands.Delete;

public sealed record DeleteUserCommand(Guid Id) : ICommand;