using BaileFunk.Models;
using MongoDB.Driver.GeoJsonObjectModel;

namespace BaileFunk.DTO_s;

public class IncidentCreateDTO
{
    public string Pseudonym { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Description { get; set; }
    public int? EstimatedPeople { get; set; }
    public List<InfractionType>? Infractions { get; set; }
    public List<string>? PhotoUrls { get; set; }
}

public class GeoLocationDTO
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}

public class IncidentResponseDTO
{
    public string Id { get; set; } = null!;
    
    public string Pseudonym { get; set; } = null!;
    
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    
    public StatusType Status { get; set; }
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public DateTime? DeactivatedAt { get; set; }

    public int? EstimatedPeople { get; set; }

    public List<InfractionType>? Infractions { get; set; }

    public List<string>? PhotoUrls { get; set; }
}