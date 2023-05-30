using Ginasio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ginasio.Services;

namespace Ginasio.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller {



        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        
        [HttpPost]
        public async Task<IActionResult> AuthAsync(Praticantes praticante)
        {
            var user = await _userManager.FindByEmailAsync(praticante.Email);
            if (user == null)
            {
                return BadRequest(new { error = "Usuário não encontrado" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, praticante.Password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = TokenService.GenerateToken(new Praticantes());
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { error = "Credenciais inválidas" });
            }
        }
    }
}

