using Ginasio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

namespace Ginasio.Services
{
    public class TokenService
    {
        /// <summary>
        /// Classe responsável por gerar o token de autenticação
        /// </summary>
        /// <param name="praticante"></param>
        /// <returns></returns>
        public static object GenerateToken(Praticantes praticante)
        {
            var key = Encoding.ASCII.GetBytes(Key.secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {

                    new Claim("praticanteId", praticante.Id.ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
