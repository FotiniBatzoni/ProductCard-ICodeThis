using MongoDB.Driver;
using System.Diagnostics.Metrics;

namespace ProductCard.Data
{
    public class CartService
    {
        private readonly IMongoCollection<Cart> _carts;

        public CartService(MongoDbClient mongoDbClient)
        {
            _carts = mongoDbClient.GetCartCollection();
        }

        public List<Cart> GetCarts()
        {
            var filter = Builders<Cart>.Filter.Empty;
            return _carts.Find(filter).ToList();
        }

        public Cart GetCartById(string cartId)
        {
            var filter = Builders<Cart>.Filter.Eq(a => a.CartId, cartId);
            return _carts.Find(filter).FirstOrDefault();
        }


        public void AddCart(Cart cart)
        {
            _carts.InsertOne(cart);
        }

        //public void EditCart(Cart cart)
        //{
        //    //var filter = Builders<Cart>.Filter.Eq(a => a.CartId, cart.CartId);
        //    //var update = Builders<Cart>.Update
        //    //    .Set(a => a.UserName, user.UserName)
        //    //    .Set(a => a.Email, user.Email)
        //    //    .Set(a => a.Password, user.Password);
        //    _carts.UpdateOne(filter, update);
        //}

        public void DeleteCart(string cartId)
        {
            var filter = Builders<Cart>.Filter.Eq(a => a.CartId, cartId);
            _carts.DeleteOne(filter);
        }
    }
}
