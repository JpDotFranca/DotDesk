using DotDesk.Application.Services.Abstraction;
using DotDesk.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace DotDesk.UserPanelBFF.Hubs;

public class WebChatHub : Hub
{
    private readonly IChatService _chatService; 

    public WebChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }
     
    public async Task SendMessage(string room, string userId, string content)
    { 
        ChatMessage message = await _chatService.StoreMessageAsync(room, userId, content);

        await Clients.Group(room).SendAsync("ReceiveMessage", message.UserId, message.Content, message.Timestamp);
    }

    public async Task JoinRoom(string room)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, room);
        await Clients.Group(room).SendAsync("UserJoined", Context.ConnectionId);
    }

    public async Task LeaveRoom(string room)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        await Clients.Group(room).SendAsync("UserLeft", Context.ConnectionId);
    }
}
