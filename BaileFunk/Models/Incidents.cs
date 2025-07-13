using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace BaileFunk.Models;

public class Incidents
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    [BsonRequired]
    [BsonElement("pseudonym")]
    public string Pseudonym { get; set; }
    
    [BsonRequired]
    [BsonElement("location")]
    public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }
    
    [BsonRequired]
    [BsonElement("status")]
    [BsonRepresentation(BsonType.String)]
    public StatusType Status { get; set; } = StatusType.Active;
    
    [BsonRequired]
    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonRequired]
    [BsonElement("createdAt")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("deactivatedAt")]
    [BsonIgnoreIfNull]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime? DeactivatedAt { get; set; } = null;
    
    [BsonIgnoreIfNull]
    [BsonElement("estimatedPeople")]
    public int? EstimatedPeople { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("infractions")]
    [BsonRepresentation(BsonType.String)]
    public List<InfractionType> Infractions { get; set; } = new();

    [BsonIgnoreIfNull]
    [BsonElement("photoUrls")]
    public List<string> PhotoUrls { get; set; } = new();
}

public enum StatusType
{
    Active,
    DeactivatedByVictim,
    DeactivatedByTimer,
    DeactivatedByAdmin
}

public enum InfractionType
{
    RoadObstruction,
    NoisePollution,
    LargeGathering
}