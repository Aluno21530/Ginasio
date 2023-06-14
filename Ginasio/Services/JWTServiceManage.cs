using Ginasio.Data;
using Ginasio.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace Ginasio.Services
{
    public class JWTServiceManage : IJWTTokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public JWTServiceManage(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _db = dbContext;
        }
        public JWTTokens Authenticate(UsersLogin user)
        {

            if (!_db.Praticantes.Any(e => e.Email == user.Email && e.Password == user.Password))
            {
                return null;
            }

            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr");
            var ToeknDescp = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(ToeknDescp);

            return new JWTTokens { Token = tokenhandler.WriteToken(token) };

        }
    }
}
