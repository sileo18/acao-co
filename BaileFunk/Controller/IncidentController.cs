using BaileFunk.DTO_s;
using BaileFunk.Mapper;
using BaileFunk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaileFunk.Controller;

[ApiController]
[Route("api/incident")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _service;

    public IncidentController(IIncidentService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Policy = "VictimOnly")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<List<IncidentResponseDTO>>> GetAllAsync()
    {
        var incidents = await _service.GetAllAsync();
        return Ok(incidents.Select(IncidentMapper.ToResponseDTO).ToList());
    }

    [HttpPost]
    [Authorize(Policy = "VictimOnly")]
    public async Task<ActionResult<IncidentResponseDTO>> InsertAsync([FromBody] IncidentCreateDTO incident)
    {
        try
        {
            var novoIncident = await _service.InsertAsync(incident);
            var response = IncidentMapper.ToResponseDTO(novoIncident);
            
            if (string.IsNullOrWhiteSpace(response.Id))
            {
                return BadRequest("ID do incidente não pode ser nulo ou vazio.");
            }
            
            return CreatedAtRoute("GetIncidentByIdAsync", new { id = response.Id }, response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Erro interno no servidor", detail = ex.Message });
        }
    }
    
    [HttpGet("{id}", Name = "GetIncidentByIdAsync")]
    public async Task<ActionResult<IncidentResponseDTO>> GetIncidentByIdAsync(string id) 
    {
        try
        {
            var incident = await _service.GetByIdAsync(id);
            
            if (incident == null)
            {
                return NotFound("Incident não encontrado");
            }
            
            return Ok(IncidentMapper.ToResponseDTO(incident));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Erro interno no servidor", detail = ex.Message });
        }
    }

    [HttpGet("near")]
    public async Task<ActionResult<List<IncidentResponseDTO>>> GetNearAsync([FromBody] GeoLocationDTO location)
    {
        var nearIncidents = await _service.GetNearAsync(location.Longitude, location.Latitude);
        return Ok(nearIncidents.Select(IncidentMapper.ToResponseDTO).ToList());
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "VictimOnly")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<bool> DeleteAsync(string id)
    {
        return await _service.DeleteAsync(id);
    }
}