using MongoDB.Driver;

namespace ProductCard.Data
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(MongoDbClient mongoDbClient)
        {
            _users = mongoDbClient.GetUserCollection();
        }

        public List<User> GetUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            return _users.Find(filter).ToList();
        }

        public User GetUserById(string userId)
        {
            var filter = Builders<User>.Filter.Eq(a => a.UserId, userId);
            return _users.Find(filter).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq(a => a.Email, email);
            return _users.Find(filter).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        public void EditUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(a => a.UserId, user.UserId);
            var update = Builders<User>.Update
                .Set(a => a.UserName, user.UserName)
                .Set(a => a.Email, user.Email)
                .Set(a => a.Password, user.Password);
            _users.UpdateOne(filter, update);
        }

        public void DeleteUser(string userId)
        {
            var filter = Builders<User>.Filter.Eq(a => a.UserId, userId);
            _users.DeleteOne(filter);
        }
    }
}
