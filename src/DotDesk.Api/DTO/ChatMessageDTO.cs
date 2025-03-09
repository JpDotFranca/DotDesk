public class ChatMessageDTO
{
    public Guid Id { get; } = Guid.NewGuid();
    public string UserId { get; set; }
    public string Room { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}