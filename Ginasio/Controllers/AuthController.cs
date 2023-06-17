using Ginasio.Models;
using Ginasio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ginasio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService) {
            _authService = authService;
        } 
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados de login inválidos");
            }

            var result = await _authService.Login(user);
            if (result)
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }

            return NotFound("Credenciais inválidas");
        }

        [Route("test")]
        [HttpGet]
        [Authorize]
        public ActionResult Test()
        {
            return Ok("Test");

        }
    }
}
