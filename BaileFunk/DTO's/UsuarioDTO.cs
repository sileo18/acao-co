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