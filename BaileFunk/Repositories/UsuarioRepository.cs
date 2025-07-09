using BaileFunk.Data;
using BaileFunk.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BaileFunk.Repositories;

public class UsuarioRepository
{
    private readonly IMongoCollection<Usuario> _collection;

    public UsuarioRepository(MongoDbContext context)
    {
        _collection = context.Usuario;
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Usuario?> GetById(string id)
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
}