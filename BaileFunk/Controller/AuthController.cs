using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaileFunk.DTO_s;
using BaileFunk.Models;
using BaileFunk.Services;
using BaileFunk.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BaileFunk.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly JwtSettings _jwtSettings;
    
    public AuthController(IUsuarioService usuarioService, IOptions<JwtSettings> jwtOptions)
    {
        _usuarioService = usuarioService;
        _jwtSettings = jwtOptions.Value;
    }
    

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO loginDto)
    {
        var usuario = await _usuarioService.AuthVictimOrAdminAsync(loginDto.Identifier, loginDto.Password);
        if (usuario == null)
        {
            return Unauthorized("Usuário ou senha inválidos.");
        }

        var token = GenerateJwtToken(usuario);

        return Ok(new { token });
    }
    private string GenerateJwtToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Username ?? usuario.Pseudonym),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        };

        // Adiciona cada role como claim
        foreach (var role in usuario.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.ToUpper())); // cuidado com o casing
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
}