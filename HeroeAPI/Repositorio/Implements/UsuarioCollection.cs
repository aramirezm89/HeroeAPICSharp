using HeroeAPI.Modelos;
using HeroeAPI.Repositorio.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio.Implements
{
    public class UsuarioCollection : IUsuarioCollection
    {
        internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
        private IMongoCollection<Usuario> Collection;
        public UsuarioCollection()
        {
            Collection = _respositorio.db.GetCollection<Usuario>("Usuarios");
        }
        public async Task DeleteUsuario(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, new ObjectId(id).ToString());
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(string id)
        {
            return await Collection.FindAsync(
              new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            await Collection.InsertOneAsync(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, usuario.Id);

            await Collection.ReplaceOneAsync(filter, usuario);
        }
    }
}
