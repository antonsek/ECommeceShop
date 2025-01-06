using Chat.Api.Abstractions;
using Chat.Api.Models;
using Microsoft.AspNetCore.SignalR;
using Shared.Result;

namespace Chat.Api.Endpoints.Chat;

internal sealed class SendMessage : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/chats/", Handler)
            .WithTags("Chat");
    }

    private static async Task<Result> Handler(SendMessageRequest request, IHubContext<ChatHub, IChatHub> hubContext)
    {
        await hubContext.Clients.Group(request.RoomId).ReceiveMessage(request.Message);

        return Result.Success();
    }
}