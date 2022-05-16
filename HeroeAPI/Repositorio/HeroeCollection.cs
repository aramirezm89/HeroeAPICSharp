using HeroeAPI.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio
{
  public class HeroeCollection : IHeroeCollection
  {

    internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
    private IMongoCollection<Heroe> Collection;
    public HeroeCollection()
    {
      Collection = _respositorio.db.GetCollection<Heroe>("Heroe");
    }
    public async Task DeleteHeroe(string id)
    {
      var filter = Builders<Heroe>.Filter.Eq(s => s.Id, new ObjectId(id));
      await Collection.DeleteOneAsync(filter);
    }

    public async Task<List<Heroe>> GetAllHeroes()
    {
      return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
    }

    public async Task<Heroe> GetHeroeById(string id)
    {
      return await Collection.FindAsync(
        new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
    }

    public async Task InsertHeroe(Heroe heroe)
    {
      await Collection.InsertOneAsync(heroe);
    }

    public async Task UpdateHeroe(Heroe heroe)
    {
      var filter = Builders<Heroe>.Filter.Eq(s => s.Id, heroe.Id);

      await Collection.ReplaceOneAsync(filter, heroe);
    }
  }
}
