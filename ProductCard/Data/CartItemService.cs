using MongoDB.Driver;
using ProductCard.Pages;

namespace ProductCard.Data
{
    public class CartItemService
    {
        private readonly IMongoCollection<CartItem> _cartItems;

        public CartItemService(MongoDbClient mongoDbClient)
        {
            _cartItems = mongoDbClient.GetCartItemCollection();
        }

        public List<CartItem> GetCartItems(string cartItemId)
        {
            var filter = Builders<CartItem>.Filter.Eq(a => a.CartItemId, cartItemId);
            return _cartItems.Find(filter).ToList();
        }

        public CartItem GetCartItemById(string cartItemId)
        {
            var filter = Builders<CartItem>.Filter.Eq(a => a.CartItemId, cartItemId);
            return _cartItems.Find(filter).FirstOrDefault();
        }


        public void AddCart(CartItem cartItem)
        {
            _cartItems.InsertOne(cartItem);
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
            var filter = Builders<CartItem>.Filter.Eq(a => a.CartId, cartId);
            _cartItems.DeleteOne(filter);
        }
    }
}
