using MongoDB.Driver;

namespace HeroeAPI.Repositorio
{
    public class MongoDbRepositorio
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDbRepositorio()
        {
            client = new MongoClient("mongodb+srv://aramirezm:ramirez1989@heroeappangular.bdmrk.mongodb.net/?retryWrites=true&w=majority");
            db = client.GetDatabase("ApiHeroe");

        }



    }
}
