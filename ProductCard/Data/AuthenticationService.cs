
using MongoDB.Driver;
using ProductCard.Helpers;
using System.Security.Claims;

namespace ProductCard.Data
{
    public class AuthenticationService
    {
        private readonly IMongoCollection<User> _users;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;

        public AuthenticationService(MongoDbClient mongoDbClient, CustomAuthenticationStateProvider customAuthenticationStateProvider)
        {
            _users = mongoDbClient.GetUserCollection();
            _customAuthenticationStateProvider = customAuthenticationStateProvider;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();

            var verifyPassword = (user.Password==password) ? true : false;

            if (user != null && verifyPassword)
            {
                var claims = new[]
                        {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                };

                var identity = new ClaimsIdentity(claims, "custom");
                var userPrincipal = new ClaimsPrincipal(identity);

                // Use the custom authentication state provider to set the authentication state
                _customAuthenticationStateProvider.SetAuthenticationState(userPrincipal);

                return true;
            }

            return false;
        }
    }
}
