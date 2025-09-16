using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
