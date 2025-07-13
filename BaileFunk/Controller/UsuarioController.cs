using BaileFunk.DTO_s;
using BaileFunk.Mapper;
using BaileFunk.Models;
using BaileFunk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaileFunk.Controller;

//[ServiceFilter(typeof(GlobalExceptionHandler))]
[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<List<UsuarioResponseDTO>> GetAllAsync([FromQuery]int pageNumber = 1,[FromQuery] int pageSize = 10)
    {
        
            List<Usuario> usuarios = await _service.GetAllAsync(pageNumber, pageSize);
            
            List<UsuarioResponseDTO> response = usuarios.Select(UsuarioMapper.ToResponseDTO)
                .ToList();

            return response;
        
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioResponseDTO>> InsertAsync([FromBody] UsuarioCreateDTO usuario)
    {
        try
        {
            Usuario novoUsuario = await _service.InsertAsync(usuario);

            var response = Mapper.UsuarioMapper.ToResponseDTO(novoUsuario);
            
            return Created("Success", response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new {message = e.Message });
        }
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync([FromQuery] string id)
    {
        var response = await _service.DeleteAsync(id);

        return response;
    }

    
    
    
}