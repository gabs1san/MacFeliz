using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepostory _pedidoRepostory;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepostory pedidoRepostory, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepostory = pedidoRepostory;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            return View();
        }
    }
}
