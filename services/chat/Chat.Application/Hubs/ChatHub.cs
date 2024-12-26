using Chat.Application.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Application;

public sealed class ChatHub : Hub<IChatHub>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} connected");
    }

    public async Task JoinChatRoom(string roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        
        await Clients.Group(roomId).JoinChatRoom($"{Context.ConnectionId} joined JoinChat");
    }

    public async Task SendMessage(string message, string roomId)
    {
        await Clients.Group(roomId).ReceiveMessage(message);
    }
}