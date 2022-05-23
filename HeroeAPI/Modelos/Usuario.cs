using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HeroeAPI.Modelos
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string usuario { get; set; }
        [MaxLength(20, ErrorMessage ="Contraseña maximo 8 caracteres")]
        [Display(Name ="Contraseña")]
        public string pass { get; set; }

        [EmailAddress(ErrorMessage = "Email no valido")]
        public string email { get; set; }

    }
}
