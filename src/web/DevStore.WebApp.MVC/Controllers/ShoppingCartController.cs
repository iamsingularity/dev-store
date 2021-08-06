using DevStore.WebApp.MVC.Models;
using DevStore.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevStore.WebApp.MVC.Controllers
{
    [Authorize, Route("shopping-cart")]
    public class ShoppingCartController : MainController
    {
        private readonly IComprasBffService _comprasBffService;

        public ShoppingCartController(IComprasBffService comprasBffService)
        {
            _comprasBffService = comprasBffService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _comprasBffService.GetShoppingCart());
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddItem(ShoppingCartItemViewModel shoppingCartItem)
        {
            var resposta = await _comprasBffService.AddShoppingCartItem(shoppingCartItem);

            if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBffService.GetShoppingCart());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update-item")]
        public async Task<IActionResult> UpdateItem(Guid productId, int quantity)
        {
            var item = new ShoppingCartItemViewModel { ProductId = productId, Quantity = quantity };
            var resposta = await _comprasBffService.AtualizarItemCarrinho(productId, item);

            if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBffService.GetShoppingCart());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("remove-item")]
        public async Task<IActionResult> RemoveItem(Guid productId)
        {
            var resposta = await _comprasBffService.RemoverItemCarrinho(productId);

            if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBffService.GetShoppingCart());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("apply-voucher")]
        public async Task<IActionResult> ApplyVoucher(string voucherCodigo)
        {
            var resposta = await _comprasBffService.AplicarVoucherCarrinho(voucherCodigo);

            if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBffService.GetShoppingCart());

            return RedirectToAction("Index");
        }
    }
}