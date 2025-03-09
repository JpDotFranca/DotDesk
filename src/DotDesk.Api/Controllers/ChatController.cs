using Microsoft.AspNetCore.Mvc;

namespace DotDesk.Api.Controllers
{ 
    public class ChatController : DotDeskControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ChatMessageDTO>>> GetChatMessages(int chatId)
        {
            List<ChatMessageDTO> messages = new()
            { 
                new ChatMessageDTO()
                {
                    UserId = "user2",
                    Room = "room1",
                    Content = "I'm good, thanks! How about you?",
                    Timestamp = DateTime.UtcNow.AddMinutes(-9)
                },
                new ChatMessageDTO()
                {
                    UserId = "user3",
                    Room = "room2",
                    Content = "Anyone here?",
                    Timestamp = DateTime.UtcNow.AddMinutes(-8)
                },
                new ChatMessageDTO()
                {
                    UserId = "user1",
                    Room = "room1",
                    Content = "I'm great, thanks for asking!",
                    Timestamp = DateTime.UtcNow.AddMinutes(-7)
                },
                new ChatMessageDTO()
                {
                    UserId = "user2",
                    Room = "room1",
                    Content = "Glad to hear that!",
                    Timestamp = DateTime.UtcNow.AddMinutes(-6)
                },
                new ChatMessageDTO()
                {
                    UserId = "user4",
                    Room = "room3",
                    Content = "Hello everyone!",
                    Timestamp = DateTime.UtcNow.AddMinutes(-5)
                },
                new ChatMessageDTO()
                {
                    UserId = "user3",
                    Room = "room2",
                    Content = "I guess not...",
                    Timestamp = DateTime.UtcNow.AddMinutes(-4)
                },
                new ChatMessageDTO()
                {
                    UserId = "user5",
                    Room = "room4",
                    Content = "Just checking in.",
                    Timestamp = DateTime.UtcNow.AddMinutes(-3)
                },
                new ChatMessageDTO()
                {
                    UserId = "user1",
                    Room = "room1",
                    Content = "See you later!",
                    Timestamp = DateTime.UtcNow.AddMinutes(-2)
                },
                new ChatMessageDTO()
                {
                    UserId = "user6",
                    Room = "room5",
                    Content = "Good morning!",
                    Timestamp = DateTime.UtcNow.AddMinutes(-1)
                }
            };
 
            return await Task.FromResult(Ok(messages));
        }
    }
}