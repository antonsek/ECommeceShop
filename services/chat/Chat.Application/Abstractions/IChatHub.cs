namespace Chat.Application.Abstractions;

public interface IChatHub
{
    Task ReceiveMessage(string message);
    Task JoinChatRoom(string message);
}