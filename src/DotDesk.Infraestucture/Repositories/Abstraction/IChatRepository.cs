using DotDesk.Domain.Entities;

namespace DotDesk.Infraestucture.Repositories.Abstraction
{
    public interface IChatRepository
    {
        Task<List<ChatMessage>> GetMessagesForRoomAsync(string room);
        Task StoreMessageAsync(ChatMessage message);
    }
}