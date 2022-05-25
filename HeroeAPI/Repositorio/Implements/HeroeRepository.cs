using HeroeAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio
{
    public class HeroeRepository : IRepositorio<Heroe>
    {

        internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
        private IMongoCollection<Heroe> Collection;
        public HeroeRepository()
        {
            Collection = _respositorio.db.GetCollection<Heroe>("Heroe");
        }
        public async Task DeleteEntity(string id)
        {
            var filter = Builders<Heroe>.Filter.Eq(s => s.Id, new ObjectId(id).ToString());
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Heroe>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Heroe> GetEntityById(string id)
        {
            return await Collection.FindAsync(
              new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertEntity(Heroe heroe)
        {
 
            await Collection.InsertOneAsync(heroe);
           
        }

        public async Task UpdateEntity(Heroe heroe)
        {
            var filter = Builders<Heroe>.Filter.Eq(s => s.Id, heroe.Id);

            await Collection.ReplaceOneAsync(filter, heroe);
        }
    }
}
