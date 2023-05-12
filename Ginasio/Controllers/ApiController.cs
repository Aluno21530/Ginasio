using Ginasio.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ginasio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("administradores")]
        public ActionResult GetAdministradores()

        {
            return Ok(_context.Administradores.ToList());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult GetAdministradoresById(int id)
        {
            if(id == 0 || _context.Administradores.Where(admin => admin.Id == id).Count()==0)
            {
                return NotFound();
            }

            return Ok(_context.Administradores.Where(admin => admin.Id==id).FirstOrDefault());
        }
        [Route("aulas")]
        [HttpGet]
        public ActionResult GetAulas() {
            return Ok(_context.Aulas.ToList());
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetAulasById(int id)
        {
            if(id == 0 || _context.Aulas.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_context.Aulas.Where(admin =>admin.Id==id).FirstOrDefault());
        }
        [Route("funcionarios")]
        [HttpGet]
        public ActionResult GetFuncionarios()
        {
            return Ok(_context.FuncionariosLimpeza.ToList());
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetFuncionarioById(int id)
        {
            if (id == 0 || _context.FuncionariosLimpeza.Where(admin => admin.Id == id).Count() == 0)
            {
                return NotFound();
            }
            return Ok(_context.FuncionariosLimpeza.Where(admin => admin.Id == id).FirstOrDefault());
        }

    }
}
