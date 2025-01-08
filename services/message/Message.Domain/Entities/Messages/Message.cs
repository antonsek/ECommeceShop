using Shared;

namespace Message.Domain.Entities.Messages;

public class Message : Entity
{
    private Message()
    {
    }
    
    public string SenderId { get; private set; }
    public string ChatId { get; private set; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool IsRead { get; private set; }
    public bool IsChanged  { get; private set; }
    public bool IsDeleted { get; private set; }
    public string Status { get; private set; }
}