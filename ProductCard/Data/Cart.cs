using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductCard.Data
{
    public class Cart
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string CartId { get; set; }

        [BsonId, BsonElement("user_id"), BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        [BsonElement("total"), BsonRepresentation(BsonType.Decimal128)]
        public Decimal Total
        {
            get
            {
                decimal total = (decimal)0.0;
                foreach (var item in Items)
                {
                    total += item.Total;
                }
                return total;
            }
        }

    }
}
