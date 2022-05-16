using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeroeAPI.Modelos
{
  public class Heroe
  {
    [BsonId]
    public ObjectId Id { get; set; }

    public string superhero { get; set; }

    public string publisher { get; set; }
    public string alter_ego { get; set; }

    public string first_appearance { get; set; }

    public string characters { get; set; }
  }
}
