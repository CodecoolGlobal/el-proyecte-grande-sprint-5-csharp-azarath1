using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using SuperDuperMedAPP.Models.DTO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperDuperMedAPP.Data.Services
{
    public class AuthService : IAuthService
    {
        readonly string _jwtSecret;
        readonly int _jwtLifespan;
        public AuthService(string jwtSecret, int jwtLifespan)
        {
            this._jwtSecret = jwtSecret;
            this._jwtLifespan = jwtLifespan;
        }
        public AuthData GetAuthData(int id, string? role)
        {
            var expirationTime = DateTime.UtcNow.AddMinutes(_jwtLifespan);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeMilliseconds(),
                Id = id,
                UserRole = role
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string? actualPassword, string? hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}