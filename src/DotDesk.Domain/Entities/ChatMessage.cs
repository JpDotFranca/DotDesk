using DotDesk.Domain.Entities.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotDesk.Domain.Entities;

public class ChatMessage: Entity
{ 
    public string UserId { get; set; }
    public string Room { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}