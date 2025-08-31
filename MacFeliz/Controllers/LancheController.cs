using MacFeliz.Repositories.Interfaces;
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

        public IActionResult List()
        {
            var lanches = _lancheRopository.Lanches;
            return View(lanches);
        }
    }
}
