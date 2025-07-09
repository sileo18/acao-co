using BaileFunk.Data;
using BaileFunk.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BaileFunk.Repositories;

public class IncidentRepository
{
    private readonly IMongoCollection<Incidents> _collection;
    
    public IncidentRepository(MongoDbContext context)
    {
        _collection = context.Incidents;
    }

    public async Task<List<Incidents>> GetAllAsync()
    {
       return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Incidents?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return null; 
        }
        return await _collection.Find(i => i.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task<Incidents> InsertAsync(Incidents incident)
    {
        await _collection.InsertOneAsync(incident);
        return incident;
    }
    
    public async Task<List<Incidents>> GetNearAsync(double longitude, double latitude, double maxDistanceInMeters)
    {
        // 1. Cria um ponto GeoJSON que representa a localização central para a busca.
        //    MongoDB.Driver.GeoJsonObjectModel.GeoJsonPoint é o tipo que representa um ponto geográfico.
        //    MongoDB.Driver.GeoJsonObjectModel.GeoJson2DCoordinates é o tipo para as coordenadas (longitude e latitude).
        var point = new MongoDB.Driver.GeoJsonObjectModel.GeoJsonPoint<MongoDB.Driver.GeoJsonObjectModel.GeoJson2DCoordinates>(
            new MongoDB.Driver.GeoJsonObjectModel.GeoJson2DCoordinates(longitude, latitude) // 2. Instancia as coordenadas com a longitude e latitude fornecidas.
        );

        // 3. Constrói um filtro de consulta para o MongoDB usando o padrão Builder.
        //    Builders<Incidents>.Filter fornece métodos para criar filtros complexos para a coleção de Incidents.
        //    .Near() é o método específico para realizar uma consulta de proximidade geoespacial.
        //    - i => i.Location: Especifica que a busca por proximidade será realizada no campo 'Location' do documento Incidents.
        //      Este campo deve ser do tipo GeoJSON Point no seu modelo e no MongoDB.
        //    - point: O ponto central a partir do qual a busca de proximidade será feita.
        //    - maxDistanceInMeters: A distância máxima em metros a partir do 'point' para incluir documentos no resultado.
        var filter = Builders<Incidents>.Filter.Near(i => i.Location, point, maxDistanceInMeters);

        // 4. Executa a consulta no MongoDB e retorna os documentos que correspondem ao filtro.
        //    _collection.Find(filter): Aplica o filtro geoespacial à coleção 'Incidents'.
        //    .ToListAsync(): Executa a operação assíncrona e converte os resultados em uma lista de objetos Incidents.
        //    await: Aguarda a conclusão da operação assíncrona antes de retornar a lista.
        return await _collection.Find(filter).ToListAsync();
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