using BaileFunk.Models;
using MongoDB.Driver;

namespace BaileFunk.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoDatabase database)
    {
        _database = database;
    }
    
    public IMongoCollection<Incidents> Incidents =>
        _database.GetCollection<Incidents>("incidents");

    public IMongoCollection<Usuario> Usuario =>
        _database.GetCollection<Usuario>("usuarios");
}