using DotDesk.Domain.Entities.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotDesk.Domain.Entities;

public class Attender : Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }  
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Attender(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Attender(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}