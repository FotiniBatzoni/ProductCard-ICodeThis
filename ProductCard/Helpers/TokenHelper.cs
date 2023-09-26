using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace ProductCard.Helpers
{
    public  class TokenHelper
    {
        private const string SecretKey = "your-secret-key";
        JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        public string GenerateToken(string userId, string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,username ),
            new Claim(ClaimTypes.Role,role),
            new Claim(ClaimTypes.NameIdentifier,userId),
        };

            var token = new JwtSecurityToken(
   
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials);

            return _tokenHandler.WriteToken(token);
        }
    }
}
