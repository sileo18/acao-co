using BaileFunk.DTO_s;
using BaileFunk.Models;

namespace BaileFunk.Services;

public interface IIncidentService
{
    Task<List<Incidents>> GetAllAsync();

    Task<List<Incidents>> GetNearAsync(double longitude, double latitude);

    Task<Incidents?> GetByIdAsync(string id);

    Task<Incidents> InsertAsync(IncidentCreateDTO incident);

    Task<bool> DeleteAsync(string id);
}