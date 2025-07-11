using BaileFunk.DTO_s;
using BaileFunk.Models;
using BaileFunk.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaileFunk.Controller;

//[ServiceFilter(typeof(GlobalExceptionHandler))]
[ApiController]
[Route("/api/usuario")]
public class UsuarioController
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<UsuarioPaginatedResponseDTO> GetAllAsync([FromQuery]int pageNumber = 1,[FromQuery] int pageSize = 10)
    {
        
            var response = await _service.GetAllAsync(pageNumber, pageSize);

            return response;
        
    }

    
    
    
}