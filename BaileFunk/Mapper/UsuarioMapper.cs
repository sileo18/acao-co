using BaileFunk.DTO_s;
using BaileFunk.Models;

namespace BaileFunk.Mapper;

public class UsuarioMapper
{
    public static UsuarioResponseDTO ToResponseDTO(Usuario usuario)
    {
        return new UsuarioResponseDTO
        {
            Id = usuario.Id.ToString(),
            Pseudonym = usuario.Pseudonym,
            Username = usuario.Username,
            Roles = usuario.Roles,
            CreatedAt = usuario.CreatedAt
        };
    }

    public static Usuario ToEntity(UsuarioCreateDTO dto)
    {
        return new Usuario
        {
            Pseudonym = dto.Pseudonym,
            Username = dto.Username,
            Password = dto.Password,
            Roles = dto.Roles,
            CreatedAt = DateTime.UtcNow
        };
    }
}