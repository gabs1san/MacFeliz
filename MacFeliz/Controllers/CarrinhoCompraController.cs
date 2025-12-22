using MacFeliz.Models;
using MacFeliz.Repositories.Interfaces;
using MacFeliz.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRopository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRopository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if(lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }

  
}
