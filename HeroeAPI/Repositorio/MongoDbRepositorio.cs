using MongoDB.Driver;

namespace HeroeAPI.Repositorio
{
  public class MongoDbRepositorio
  {
    public MongoClient client;
    public IMongoDatabase db;

    public MongoDbRepositorio()
    {
      client = new MongoClient("mongodb://localhost:27017");
      db = client.GetDatabase("ApiHeroe");

    }

  }
}
