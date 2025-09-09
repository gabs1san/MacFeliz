using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using MacFeliz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MacFeliz.Controllers
{
    public class HomeController : Controller
    {
        
        private  readonly ILancheRopository _lancheRopository;

        public HomeController(ILancheRopository lancheRopository)
        {
            _lancheRopository = lancheRopository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRopository.LanchesPreferidos
            };

            return View(homeViewModel);
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
