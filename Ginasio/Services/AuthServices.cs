using Ginasio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ginasio.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;



        public AuthServices(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> Register(LoginUser user)
        {
            var username = user.Username.Split('@')[0];
            var identityUser = new IdentityUser
            {
                UserName = username,
                Email = user.Username
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
        
        public async  Task<bool> Login(LoginUser user)
        {
             var identityUser = await _userManager.FindByEmailAsync(user.Username);
            if(identityUser == null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateTokenString(LoginUser user)
        {

            IEnumerable<System.Security.Claims.Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Username),

            };
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("TtRNWIPF2AWEiy_8NAPesssLUdAJKABSKkajakaao2221223"));
            var signingCred = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256Signature
                );
            var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    issuer:_configuration.GetSection("JWT:Issuer").Value,
                    audience: _configuration.GetSection("JWT:Audience").Value,
                    signingCredentials:signingCred
                ) ;
            var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }


    }
}
