using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using MacFeliz.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRopository _lancheRopository;

        public LancheController(ILancheRopository lancheRopository)
        {
            _lancheRopository = lancheRopository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRopository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRopository.Lanches
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRopository.Lanches
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //        .OrderBy(l => l.Nome);
                //}

                lanches = _lancheRopository.Lanches
                          .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                          .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRopository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
     
    }
}