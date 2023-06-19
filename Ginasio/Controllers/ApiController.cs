using Ginasio.Data;
using Ginasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Ginasio.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ginasio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public ApiController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        /// <summary>
        /// GET dos administradores
        /// </summary>
        [Authorize]
        [HttpGet]
        [Route("administradores")]
        public ActionResult GetAdministradores()

        {
            return Ok(_db.Administradores.ToList());
        }
        /// <summary>
        /// GET dos administradores pelo Id
        /// </summary>
        [Authorize]
        [Route("administradores/{id}")]
        [HttpGet]
        public ActionResult GetAdministradoresById(int id)
        {
            if(id == 0 || _db.Administradores.Where(admin => admin.Id == id).Count()==0)
            {
                return NotFound();
            }

            return Ok(_db.Administradores.Where(admin => admin.Id==id).FirstOrDefault());
        }
        /// <summary>
        /// POST dos administradores
        /// </summary>
        [Authorize]
        [HttpPost("administradores/create")]
        public IActionResult CreateAdministrador(Administradores administradores)
        {

            _db.Add(administradores);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetAdministradores), new { id = administradores.Id }, administradores);
        }
        /// <summary>
        /// GET das aulas
        /// </summary>
        [Authorize]
        [Route("aulas")]
        [HttpGet]
        public ActionResult GetAulas() {
            return Ok(_db.Aulas.ToList());
        }
        /// <summary>
        /// GET das aulas pelo Id
        /// </summary>
        [Authorize]
        [Route("aulas/{id}")]
        [HttpGet]
        public ActionResult GetAulasById(int id)
        {
            if(id == 0 || _db.Aulas.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_db.Aulas.Where(admin =>admin.Id==id).FirstOrDefault());
        }
        /// <summary>
        /// POST das aulas
        /// </summary>
        [Authorize]
        [HttpPost("aulas/create")]
        public IActionResult CreateAula(Aulas aulas)
        {

            _db.Add(aulas);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetAulas), new { id = aulas.Id }, aulas);
        }
        /// <summary>
        /// GET dos funcionários
        /// </summary>
        [Authorize]
        [Route("funcionarios")]
        [HttpGet]
        public ActionResult GetFuncionarios()
        {
            return Ok(_db.FuncionariosLimpeza.ToList());
        }
        /// <summary>
        /// GET dos funcionários pelo Id
        /// </summary>
        [Authorize]
        [Route("funcionarios/{id}")]
        [HttpGet]
        public ActionResult GetFuncionarioById(int id)
        {
            if (id == 0 || _db.FuncionariosLimpeza.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_db.FuncionariosLimpeza.Where(admin => admin.Id == id).FirstOrDefault());
        }
        /// <summary>
        /// POST dos funcionários
        /// </summary>
        [Authorize]
        [HttpPost("funcionarios/create")]
        public IActionResult CreateFuncionario(FuncionariosLimpeza funcionario)
        {

            _db.Add(funcionario);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetFuncionarios), new { id = funcionario.Id }, funcionario);
        }
        /// <summary>
        /// GET dos instrutores
        /// </summary>
        [Authorize]
        [Route("instrutores")]
        [HttpGet]
        public ActionResult GetInstrutores()
        {
            return Ok(_db.Instrutores.ToList());
        }
        /// <summary>
        /// GET dos instrutores pelo Id
        /// </summary>
        [Authorize]
        [Route("instrutores/{id}")]
        [HttpGet]
        public ActionResult GetInstrutorById(int id)
        {
            if (id == 0 || _db.Instrutores.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_db.Instrutores.Where(admin => admin.Id == id).FirstOrDefault());
        }
        /// <summary>
        /// POST dos instrutores
        /// </summary>
        [HttpPost("instrutores/create")]
        public IActionResult CreateInstrutor(Instrutores instrutor)
        {

            _db.Add(instrutor);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetInstrutores), new { id = instrutor.Id }, instrutor);
        }
        /// <summary>
        /// GET dos praticantes
        /// </summary>
        [Authorize]
        [Route("praticantes")]
        [HttpGet]
        public ActionResult GetPraticantes()
        {
            return Ok(_db.Praticantes.ToList());
        }
        /// <summary>
        /// GET dos praticantes pelo Email
        /// </summary>
        [Authorize]
        [Route("praticantes/{email}")]
        [HttpGet]
        public ActionResult GetPraticanteByEmail(string email)
        {
            if (email == null || _db.Praticantes.Where(admin => admin.Email == email).Count() == 0 )
            {
                return NotFound();
            }
            return Ok(_db.Praticantes.Where(admin => admin.Email == email).FirstOrDefault());
        }
        /// <summary>
        /// POST dos praticantes
        /// </summary>
        [HttpPost("praticantes/create")]
        public async Task<IActionResult> CreatePraticanteAsync([FromBody] Praticantes praticante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar se o usuário já existe
            if (await _db.Praticantes.AnyAsync(u => u.Email == praticante.Email))
            {
                return Conflict(new { mensagem = "O usuário já existe" });
            }
            if(praticante == null) {
                return BadRequest("Insira as informações necessárias");
            
            }
            var username = praticante.Email.Split()[0];
            // Salvar o novo usuário no banco de dados
            var loginUser = new LoginUser
            {
                Username = username,
                Password = praticante.Password
            };
            var identityUser = new IdentityUser
            {
                UserName = loginUser.Username,
                Email = praticante.Email,
                
            };
            var userId = await _userManager.GetUserIdAsync(identityUser);
            var result = await _userManager.CreateAsync(identityUser, loginUser.Password);
            if (result.Succeeded)
            {
                praticante.UserId = userId;
                _db.Add(praticante);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPraticantes), new { id = praticante.Id }, praticante);
            }

            return BadRequest("Ocorreu algum erro");
        }
        /// <summary>
        /// GET dos treinamentos
        /// </summary>
        [Authorize]
        [Route("treinamentos")]
        [HttpGet]
        public ActionResult GetTreinamentos()
        {
            return Ok(_db.Treinamentos.ToList());
        }
        /// <summary>
        /// GET dos treinamentos pelo Id
        /// </summary>
        [Authorize]
        [Route("treinamentos/{id}")]
        [HttpGet]
        public ActionResult GetTreinamentoById(int id)
        {
            if (id == 0 || _db.Treinamentos.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_db.Treinamentos.Where(admin => admin.Id == id).FirstOrDefault());
        }
        /// <summary>
        /// POST dos administradores
        /// </summary>
        [Authorize]
        [HttpPost("treinamentos/create")]
        public IActionResult CreateTreinamento(Treinamentos treinamento)
        {

            _db.Add(treinamento);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetTreinamentos), new { id = treinamento.Id }, treinamento);
        }

        /// <summary>
        /// GET das fotografias
        /// </summary>
        [Authorize]
        [HttpGet]
        [Route("fotografias")]
        public ActionResult GetFotografias()

        {
            return Ok(_db.Fotografias.ToList());
        }
        /// <summary>
        /// GET dos administradores pelo Id
        /// </summary>
        [Authorize]
        [Route("fotografias/{id}")]
        [HttpGet]
        public ActionResult GetFotografiasById(int id)
        {
            if (id == 0 || _db.Fotografias.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }

            return Ok(_db.Fotografias.Where(admin => admin.Id == id).FirstOrDefault());
        }
        /// <summary>
        /// POST das fotografias
        /// </summary>
        [Authorize]
        [HttpPost("fotografias/create")]
        public IActionResult CreateFotografia(Fotografias fotografias)
        {

            _db.Add(fotografias);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetFotografias), new { id = fotografias.Id }, fotografias);
        }
        
    }
}
