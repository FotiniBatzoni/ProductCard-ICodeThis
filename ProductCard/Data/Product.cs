using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductCard.Data
{
    public class Product
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("product_name"), BsonRepresentation(BsonType.String)]
        public string ProductName { get; set; }


        [BsonElement("price"), BsonRepresentation(BsonType.Int32)]
        public int Price { get; set; }

        [BsonElement("image"), BsonRepresentation(BsonType.String)]
        public string Image { get; set; }

       
    }
}
