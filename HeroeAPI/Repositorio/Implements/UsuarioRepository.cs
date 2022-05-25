using HeroeAPI.Modelos;
using HeroeAPI.Repositorio.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio.Implements
{
    public class UsuarioRepository : IRepositorio<Usuario>
    {
        internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
        private IMongoCollection<Usuario> Collection;
        public UsuarioRepository()
        {
            Collection = _respositorio.db.GetCollection<Usuario>("Usuarios");
        }
        public async Task DeleteEntity(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, new ObjectId(id).ToString());
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Usuario> GetEntityById(string id)
        {
            return await Collection.FindAsync(
              new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertEntity(Usuario usuario)
        {
            await Collection.InsertOneAsync(usuario);
        }

        public async Task UpdateEntity(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, usuario.Id);

            await Collection.ReplaceOneAsync(filter, usuario);
        }
    }
}
