using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductCard.Data
{
    public class Cart
    {
        public List<ProductCart> Items { get; set; } = new List<ProductCart>();

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
