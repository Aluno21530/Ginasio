using Ginasio.Data;
using Ginasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


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
        [Route("aulas")]
        [HttpGet]
        public ActionResult GetAulas() {
            return Ok(_db.Aulas.ToList());
        }
        /// <summary>
        /// GET das aulas pelo Id
        /// </summary>
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
        /// GET das aulas de um praticante, dado seu email
        /// </summary>
        
        [Route("praticantes/{email}/aulas")]
        [HttpGet]
        public ActionResult GetAulasByEmail(string email)
        {
            var praticante = _db.Praticantes.Where(admin => admin.Email == email).FirstOrDefault();
            var aulas = praticante.ListaAulas.ToList();
            return Ok(aulas);
        }
        /// <summary>
        /// GET dos treinos de um praticante, dado seu email
        /// </summary>
        
        [Route("praticantes/{email}/treinos")]
        [HttpGet]
        public ActionResult GetTreinosByEmail(string email)
        {
            var praticante = _db.Praticantes.Where(admin => admin.Email == email).FirstOrDefault();
            var treinos = praticante.ListaTreinamentos.ToList();
            return Ok(treinos);
        }
        /// <summary>
        /// GET do praticante pelo Email
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
            var username = praticante.Email.Split('@')[0];
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
                _db.Add(loginUser);
                _db.Add(praticante);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPraticantes), new { id = praticante.Id }, praticante);
            }

            return BadRequest("Ocorreu algum erro");
        }
        [Authorize]
        [HttpPut("praticantes/edit/{email}")]
        public async Task<IActionResult> UpdatePraticanteAsync(string? email, [FromBody] Praticantes praticante)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var praticanteExistente = await _db.Praticantes.FirstOrDefaultAsync(p => p.Email == email);

            if (praticanteExistente == null)
            {
                return NotFound();
            }

            if (await _db.Praticantes.AnyAsync(u => u.Email == praticante.Email && u.Id != praticanteExistente.Id))
            {
                return Conflict(new { mensagem = "O email já está sendo usado por outro praticante." });
            }

            var usernameUser = praticanteExistente.Email.Split('@')[0];
            var identityExistente = await _userManager.FindByEmailAsync(praticanteExistente.Email);
            var userExistente = await _db.LoginUser.FirstOrDefaultAsync(p => p.Username == usernameUser);

            if (userExistente != null)
            {
                _db.LoginUser.Remove(userExistente);
                await _db.SaveChangesAsync();
            }
            var newUser = new LoginUser
            {
                Username = praticante.Email.Split('@')[0],
                Password = praticante.Password
            };
            praticanteExistente.Password = praticante.Password;
            praticanteExistente.Morada = praticante.Morada;
            praticanteExistente.Telemovel = praticante.Telemovel;
            praticanteExistente.Email = praticante.Email;
            identityExistente.UserName = praticante.Email.Split('@')[0];
            identityExistente.Email = praticante.Email;

            await _userManager.UpdateAsync(identityExistente);
             _db.LoginUser.Add(newUser);
            await _db.SaveChangesAsync();

            return Ok(praticante);
        }

        [Authorize]
        [HttpDelete("praticantes/delete/{email}")]
        public async Task<IActionResult> DeletePraticanteAsync(string? email)
        {
            var praticanteExistente = await _db.Praticantes.FirstOrDefaultAsync(p => p.Email == email);

            if (praticanteExistente == null)
            {
                return NotFound();
            }

            var usernameUser = praticanteExistente.Email.Split('@')[0];
            var identityExistente = await _userManager.FindByEmailAsync(praticanteExistente.Email);
            var userExistente = await _db.LoginUser.FirstOrDefaultAsync(p => p.Username == usernameUser);

            if (userExistente != null)
            {
                _db.LoginUser.Remove(userExistente);
                await _db.SaveChangesAsync();
            }

            _db.Praticantes.Remove(praticanteExistente);
            await _db.SaveChangesAsync();

            await _userManager.DeleteAsync(identityExistente);

            return Ok();
        }


        /// <summary>
        /// GET dos treinamentos
        /// </summary>
        [Route("treinamentos")]
        [HttpGet]
        public ActionResult GetTreinamentos()
        {
            return Ok(_db.Treinamentos.ToList());
        }
        /// <summary>
        /// GET dos treinamentos pelo Id
        /// </summary>
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
