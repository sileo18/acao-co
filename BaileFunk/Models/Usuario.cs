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
    
    [BsonElement("username")]
    public string? Username { get; set; }
    
    [BsonRequired]
    [BsonElement("password")]
    public string Password { get; set; }

    [BsonRequired]
    [BsonElement("roles")]
    public List<string> Roles { get; set; } = new List<string>() ;
    
    [BsonIgnoreIfNull]
    [BsonElement("createdAt")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    
}