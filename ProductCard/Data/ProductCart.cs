using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductCard.Data
{
    public class ProductCart
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string CartProductId { get; set; }

        [BsonElement("quantity"), BsonRepresentation(BsonType.Int32)]
        public int Quantity { get; set; }


        [BsonElement("Product")]
        public Product Product { get; set; }

        [BsonElement("total"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Total
        {
            get
            {
                return (Product.Price) * Quantity;
            }
        }
    }
}
