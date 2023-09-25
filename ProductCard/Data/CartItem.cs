using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductCard.Data
{
    public class CartItem
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string CartItemId { get; set; }

        [BsonId, BsonElement("cart_id"), BsonRepresentation(BsonType.ObjectId)]
        public string CartId { get; set; }

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
