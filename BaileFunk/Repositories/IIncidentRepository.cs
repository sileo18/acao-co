using BaileFunk.Models;

namespace BaileFunk.Repositories;

public interface IIncidentRepository
{
    Task<List<Incidents>> GetAllAsync();

    Task<Incidents?> GetByIdAsync(string id);

    Task<Incidents> InsertAsync(Incidents incidents);

    Task<List<Incidents>> GetNearAsync(double longitude, double latitude, double maxDistanceInMeters);

    Task<bool> DeleteAsync(string id);


}