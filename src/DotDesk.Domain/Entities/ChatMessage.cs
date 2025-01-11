namespace DotDesk.Domain.Entities;

public class ChatMessage
{
    public string UserId { get; set; }
    public string Room { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}
 