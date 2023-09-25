using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductCard.Data
{
    public class User
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("user_name"), BsonRepresentation(BsonType.String)]
        public string UserName { get; set; }


        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("passsword"), BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonElement("role"), BsonRepresentation(BsonType.String)]
        public string Role { get; set; }

        [BsonElement("token"), BsonRepresentation(BsonType.String)]
        public string Token { get; set; }
    }
}
