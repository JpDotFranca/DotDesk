using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotDesk.Domain.Entities;

public class ChatMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } // Internally stored as ObjectId, viewed as string
    public string UserId { get; set; }
    public string Room { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}