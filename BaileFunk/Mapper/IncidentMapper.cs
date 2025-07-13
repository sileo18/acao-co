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

    public static IncidentResponseDTO ToResponseDTO(Incidents entity)
    {
        return new IncidentResponseDTO
        {
            Id = entity.Id.ToString(),
            Pseudonym = entity.Pseudonym,
            Description = entity.Description,
            EstimatedPeople = entity.EstimatedPeople,
            Infractions = entity.Infractions,
            PhotoUrls = entity.PhotoUrls,
            Status = entity.Status,
            Latitude = entity.Location.Coordinates.Y,
            Longitude = entity.Location.Coordinates.X,
            CreatedAt = entity.CreatedAt,
            DeactivatedAt = entity.DeactivatedAt
        };
    }
}