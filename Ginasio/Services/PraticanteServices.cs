using Ginasio.Data;
using Ginasio.Models;

namespace Ginasio.Services
{
    public class PraticanteServices : IPraticantes
    {
        private ApplicationDbContext _db;

        public PraticanteServices(ApplicationDbContext dbContextData)
        {
            _db = dbContextData;
        }
        public IEnumerable<Praticantes> GetAll()
        {
            return _db.Praticantes;
        }
    }
}
