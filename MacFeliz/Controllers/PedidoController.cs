﻿using MacFeliz.Models;
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
            int totalIntensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, qual escolher um lanche...");
            }

            foreach (var item in items)
            {
                totalIntensPedido += item.Quantidade;
                precoTotalPedido += item.Lanche.Preco * item.Quantidade;
            }

            pedido.TotalItensPedido = totalIntensPedido;
            pedido.PedidoTotal = precoTotalPedido;

            if (ModelState.IsValid)
            {
                _pedidoRepostory.CriarPedido(pedido);
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido ;)";
                ViewBag.TotaPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                _carrinhoCompra.LimparCarrinho();
                return View("~View/Pedido/CheckOutCompleto.cshtml", pedido);
            }
            return View(pedido);
        }
    }
}
