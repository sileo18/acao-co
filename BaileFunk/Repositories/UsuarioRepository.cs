using BaileFunk.Data;
using BaileFunk.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BaileFunk.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IMongoCollection<Usuario> _collection;

    UsuarioRepository(MongoDbContext context)
    {
        _collection = context.Usuario;
    }

    public async Task<List<Usuario>> GetAllAsync(int skip, int pageSize)
    {
        return await _collection.Find(_ => true)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<Usuario?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return null; 
        }
        
        return await _collection.Find(i => i.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task<Usuario> InsertAsync(Usuario usuario)
    {
        await _collection.InsertOneAsync(usuario);
        return usuario;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return false;
        }

        var result = await _collection.DeleteOneAsync(i => i.Id == objectId);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<Usuario?> GetByPseudonymOrUsernameAsync(string identifier)
    {
        var filter = Builders<Usuario>.Filter.Or(
            Builders<Usuario>.Filter.Eq(u => u.Pseudonym, identifier),
            Builders<Usuario>.Filter.Eq(u => u.Username, identifier)
        );
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}