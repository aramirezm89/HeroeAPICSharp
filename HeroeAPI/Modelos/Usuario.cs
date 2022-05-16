using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeroeAPI.Modelos
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string email { get; set; }

    }
}
