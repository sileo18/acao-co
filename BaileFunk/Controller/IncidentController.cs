using BaileFunk.DTO_s;
using BaileFunk.Mapper;
using BaileFunk.Services;
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
    public async Task<ActionResult<List<IncidentResponseDTO>>> GetAllAsync()
    {
        var incidents = await _service.GetAllAsync();
        return Ok(incidents.Select(IncidentMapper.ToResponseDTO).ToList());
    }

    [HttpPost]
    [HttpPost]
    public async Task<ActionResult<IncidentResponseDTO>> InsertAsync([FromBody] IncidentCreateDTO incident)
    {
        try
        {
            var novoIncident = await _service.InsertAsync(incident);
            var response = IncidentMapper.ToResponseDTO(novoIncident);
            return Created("daqui a pouco arrumo", response);
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

    [HttpPost("near")]
    public async Task<ActionResult<List<IncidentResponseDTO>>> GetNearAsync([FromBody] GeoLocationDTO location)
    {
        var nearIncidents = await _service.GetNearAsync(location.Longitude, location.Latitude);
        return Ok(nearIncidents.Select(IncidentMapper.ToResponseDTO).ToList());
    }
}