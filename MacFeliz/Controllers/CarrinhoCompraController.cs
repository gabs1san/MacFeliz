using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        private readonly ILancheRopository _lancheRopository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRopository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRopository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            return View();
        }
    }

  
}
