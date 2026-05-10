using MacFeliz.Context;
using MacFeliz.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MacFeliz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminRelatorioVendasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? dataInicial, DateTime? dataFinal)
        {
            var pedidos = _context.Pedidos.AsQueryable();

            if (dataInicial.HasValue)
            {
                pedidos = pedidos.Where(p => p.PedidoEnviado >= dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                pedidos = pedidos.Where(p => p.PedidoEnviado <= dataFinal.Value);
            }

            var listaPedidos = await pedidos.ToListAsync();

            var viewModel = new RelatorioVendasViewModel
            {
                TotalPedidos = listaPedidos.Count,

                TotalVendas = listaPedidos.Sum(p => p.PedidoTotal),

                TotalProdutosVendidos = listaPedidos.Sum(p => p.TotalItensPedido),

                DataInicial = dataInicial,

                DataFinal = dataFinal
            };

            return View(viewModel);
        }
    }
}