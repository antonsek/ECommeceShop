namespace Chat.Application.Models;

public class SendMessageRequest
{
    public string RoomId { get; set; }
    public string Message { get; set; }
}