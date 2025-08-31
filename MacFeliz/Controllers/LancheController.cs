using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class LancheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
