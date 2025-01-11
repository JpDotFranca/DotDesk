using DotDesk.Application.Services.Abstraction;
using DotDesk.Domain.Entities;
using DotDesk.Infraestucture.Repositories.Abstraction;

namespace DotDesk.Application.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _repository;

    public ChatService(IChatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChatMessage> StoreMessageAsync(string room, string userId, string content)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Message content cannot be empty", nameof(content));
        }

        // Create a new message
        ChatMessage message = new()
        {
            UserId = userId,
            Room = room,
            Content = content,
            Timestamp = DateTime.UtcNow
        };

        // Save to database
        await _repository.StoreMessageAsync(message);

        return message;
    }

    public async Task<List<ChatMessage>> GetMessagesForRoomAsync(string room)
    {
        // Retrieve messages from the repository
        return await _repository.GetMessagesForRoomAsync(room);
    }
}
