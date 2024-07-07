using CoensioApi.Data.Dtos;
using CoensioApi.Services.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoensioApi.Services.Concretes
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;
        private const double Expire_Hours = 2000;
        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }


        public dtoToken CreateAccessToken(ClaimsIdentity identity)
        {
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:Key").Value);
            Console.WriteLine(key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddHours(Expire_Hours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(descriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new dtoToken
            {
                AccessToken = accessToken,
                TokenType = "bearer"
            };
        }
       
    }
}
