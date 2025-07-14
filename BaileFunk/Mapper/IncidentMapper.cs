using BaileFunk.DTO_s;
using BaileFunk.Models;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace BaileFunk.Mapper;

public class IncidentMapper
{
    public static Incidents ToEntity(IncidentCreateDTO dto)
    {
        return new Incidents
        {
            Pseudonym = dto.Pseudonym,
            Description = dto.Description,
            EstimatedPeople = dto.EstimatedPeople,
            Infractions = dto.Infractions ?? new List<InfractionType>(),
            PhotoUrls = dto.PhotoUrls ?? new List<string>(),
            Status = StatusType.Active,
            Location = new GeoJsonPoint<GeoJson2DCoordinates>(
                new GeoJson2DCoordinates(dto.Longitude, dto.Latitude)
            )
        };
    }

    public static IncidentResponseDTO ToResponseDTO(Incidents incident)
    {
        return new IncidentResponseDTO
        {
            Id = incident.Id.ToString(),
            Pseudonym = incident.Pseudonym,
            Longitude = incident.Location.Coordinates.X,
            Latitude = incident.Location.Coordinates.Y,
            Status = incident.Status,
            Description = incident.Description,
            CreatedAt = incident.CreatedAt,
            DeactivatedAt = incident.DeactivatedAt,
            EstimatedPeople = incident.EstimatedPeople,
            Infractions = incident.Infractions,
            PhotoUrls = incident.PhotoUrls
        };
    }
}