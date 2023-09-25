using MongoDB.Driver;

namespace ProductCard.Data
{
    public class MongoDbClient
    {
        private readonly IMongoDatabase _database;

        public MongoDbClient(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            var databaseName = "ProductCartICodeThis";
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Product> GetProductCollection()
        {
            return _database.GetCollection<Product>("product");
        }

        public IMongoCollection<User> GetUserCollection()
        {
            return _database.GetCollection<User>("user");
        }

        public IMongoCollection<Cart> GetCartCollection()
        {
            return _database.GetCollection<Cart>("cart");
        }

        public IMongoCollection<CartItem> GetCartItemCollection()
        {
            return _database.GetCollection<CartItem>("productCart");
        }
    }
}
