using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaileFunk.Models;

public class Usuario
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    [BsonRequired]
    [BsonElement("pseudonym")]
    public string Pseudonym { get; set; }
    
    [BsonIgnoreIfNull]
    [BsonElement("username")]
    public string? Username { get; set; }
    
    [BsonRequired]
    [BsonElement("password")]
    public string Password { get; set; }

    [BsonRequired]
    public List<string> Roles = new List<string>();
    
    [BsonIgnoreIfNull]
    [BsonElement("createdAt")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    
}