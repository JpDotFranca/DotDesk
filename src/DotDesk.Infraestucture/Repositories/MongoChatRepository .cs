using DotDesk.Domain.Entities;
using DotDesk.Infraestucture.Repositories.Abstraction;
using MongoDB.Driver;

namespace DotDesk.Infrastructure.Repositories;

public class MongoChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatMessage> _messages;

    public MongoChatRepository(IMongoDatabase database)
    {
        _messages = database.GetCollection<ChatMessage>("Messages");
    }

    public async Task StoreMessageAsync(ChatMessage message)
    {
        await _messages.InsertOneAsync(message);
    }

    public async Task<List<ChatMessage>> GetMessagesForRoomAsync(string room)
    {
        return await _messages
            .Find(m => m.Room == room)
            .SortBy(m => m.Timestamp)
            .ToListAsync();
    }
}
