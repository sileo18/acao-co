using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaileFunk.DTO_s;

public class UsuarioPaginatedResponseDTO
{
    public ObjectId Id { get; set; }
    public string Pseudonym { get; set; }
    public string? Username { get; set; }
    
    public List<string> Roles = new List<string>();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

}

public class UsuarioCreateDTO
{
    public string Pseudonym { get; set; } = null!;
    public string? Username { get; set; }
    public string Password { get; set; } = null!;
    public List<string> Roles { get; set; } = new List<string>();
}

public class UsuarioResponseDTO
{
    public string Id { get; set; } = null!;
    public string Pseudonym { get; set; } = null!;
    public string? Username { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
    public DateTime? CreatedAt { get; set; }
}

public class UsuarioLoginDTO
{
    public string Identifier { get; set; } = null!;
    public string Password { get; set; } = null!;
}