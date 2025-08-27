using MacFeliz.Context;
using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MacFeliz.Repositories
{
    public class LancheRpository : ILancheRopository
    {


        private readonly AppDbContext _context;
        public LancheRpository(AppDbContext contexto)
        {
            _context = contexto;   
        }
        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c=> c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanche.
            Where(l => l.IsLanchePreferido).
            Include(c => c.Categoria);


        public Lanche GeLancheById(int LancheId)
        {
            return _context.Lanche.FirstOrDefault(l => l.LancheId == LancheId);
        }
    } 
}
