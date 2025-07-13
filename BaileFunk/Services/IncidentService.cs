using BaileFunk.DTO_s;
using BaileFunk.Mapper;
using BaileFunk.Models;
using BaileFunk.Repositories;

namespace BaileFunk.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _repository;

    private readonly IUsuarioRepository _usuarioRepository;
    
    private double MAX_DISTANCE_IN_METERS = 3000;

    public IncidentService(IIncidentRepository repository, IUsuarioRepository usuarioRepository)
    {
        _repository = repository;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<List<Incidents>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<List<Incidents>> GetNearAsync(double longitude, double latitude)
    {
        return await _repository.GetNearAsync(longitude, latitude, MAX_DISTANCE_IN_METERS);
    }

    public async Task<Incidents?> GetByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Incidents> InsertAsync(IncidentCreateDTO incident)
    {
        var existsUser = await _usuarioRepository.GetByPseudonymOrUsernameAsync(incident.Pseudonym);

        if (existsUser == null)
            throw new ArgumentException("Usuário não encontrado.");

        var existingActiveIncident = await _repository.GetActiveByPseudonymAsync(incident.Pseudonym);

        if (existingActiveIncident != null)
            throw new InvalidOperationException("O usuário já possui um incidente ativo.");

        var incidentEntity = IncidentMapper.ToEntity(incident);

        return await _repository.InsertAsync(incidentEntity);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _repository.DeleteAsync(id);
    }
}