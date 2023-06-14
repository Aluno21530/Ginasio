using Ginasio.Data;
using Ginasio.Models;

using Ginasio.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Ginasio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IPraticantes _Praticantes;
        private readonly IJWTTokenServices _jwttokenservice;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public AuthController(IPraticantes praticantes, IJWTTokenServices jWTTokenServices, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, ApplicationDbContext context )
        {
            _Praticantes = praticantes;
            _jwttokenservice = jWTTokenServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_Praticantes.GetAll());
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate( UsersLogin user)
        {
            var token = _jwttokenservice.Authenticate(user);

            if (token == null)
            {
                return Ok(new { Message = "Acesso negado" });
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Praticantes praticante)
        {
            if (await _db.Praticantes.AnyAsync(u => u.Email == praticante.Email))
            {
                return Conflict(new { mensagem = "O usuário já existe" });
            }
            var user = new UsersLogin
            {
                UserName = praticante.Email.Split('@')[0],
                Password = praticante.Password,
                Email = praticante.Email
            };
            // Salvar o novo usuário no banco de dados
            _db.Add(user);
            _db.Add(praticante);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = praticante.Id }, praticante);
        }

        private bool UsuarioExiste(string email)
        {
            return(_userManager.Users.AsNoTracking().Any(u => u.Email == email));
        }

        private static void UserToIdentity(Praticantes user, IdentityUser identity)
        {
            identity.Email = user.Email;
            identity.NormalizedUserName = user.Email.Split('@')[0].ToUpper().Trim();
            identity.UserName = user.Email.Split('@')[0];
            identity.NormalizedEmail = user.Email.ToUpper().Trim();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Cadastrar([FromForm] UsersLogin user)
        {
            //se for alteração, não tem senha
            if(!string.IsNullOrEmpty(user.Email))
            {
                ModelState.Remove("Password");
            }
            if(ModelState.IsValid)
            {
                if(UsuarioExiste(user.Email))
                {
                    var praticante = await _userManager.FindByEmailAsync(user.Email);
                    if((user.Email != praticante.Email && 
                        (_userManager.Users.Any(u => u.NormalizedEmail == user.Email.ToUpper().Trim()))))
                    {
                        ModelState.AddModelError("Email","E-mail ja existente");
                    }
                    UserToIdentity(user, praticante);

                    var resultado = await _userManager.UpdateAsync(praticante);
                    if(resultado.Succeeded)
                    {
                        return Ok("Usuário alterado com sucesso");
                    }
                }
                else
                {
                    return BadRequest("Não foi possível alterar o usuário");
                }
            }
            else
            {
                var praticante = await _userManager.FindByEmailAsync(user.Email);
                if(praticante != null)
                {
                    ModelState.AddModelError("Email", "Usuário ja cadastrado com esse email");
                }
                praticante = new IdentityUser();
                UserToIdentity(user, praticante);
                var resultado = await _userManager.CreateAsync(praticante, user.Password);
                if(resultado.Succeeded)
                {
                    return Ok("Usuário cadastrado com sucesso!");
                }
            }
            return Ok();
        }
    }
}

