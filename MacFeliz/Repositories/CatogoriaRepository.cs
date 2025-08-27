using MacFeliz.Context;
using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;

namespace MacFeliz.Repositories
{
    public class CatogoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CatogoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
