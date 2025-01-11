using DotDesk.Domain.Entities;

namespace DotDesk.Application.Services.Abstraction
{
    public interface IChatService
    {
        Task<ChatMessage> StoreMessageAsync(string room, string userId, string content);
        Task<List<ChatMessage>> GetMessagesForRoomAsync(string room);
    }
}
