﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotDesk.Domain.Entities.Abstractions;

public abstract class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } 
}