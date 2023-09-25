using MongoDB.Driver;

namespace ProductCard.Data
{
    public class ProductService
    {
     
        private readonly IMongoCollection<Product> _products;

        public ProductService(MongoDbClient mongoDbClient)
        {
            _products = mongoDbClient.GetProductCollection();
        }

        public List<Product> GetProducts()
        {
            var filter = Builders<Product>.Filter.Empty;
            return _products.Find(filter).ToList();
        }

        public Product GetProductById(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.ProductId, productId);
            return _products.Find(filter).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _products.InsertOne(product);
        }

        public void EditProduct(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.ProductId, product.ProductId);
            var update = Builders<Product>.Update
                .Set(a => a.ProductName, product.ProductName)
                .Set(a => a.Price, product.Price)
                .Set(a => a.Image, product.Image);
            _products.UpdateOne(filter, update);
        }

        public void DeleteProduct(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(a => a.ProductId, productId);
            _products.DeleteOne(filter);
        }
    }
}
