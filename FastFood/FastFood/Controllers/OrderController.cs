using FastFood.Contracts;
using FastFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService service;

        private readonly ShoppingCart shoppingCart;

        public OrderController(IOrderService service, ShoppingCart shoppingCart)
        {
            this.service = service;
            this.shoppingCart = shoppingCart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.Items = items;

            if(shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some foods first.");
            }
            if (ModelState.IsValid)
            {
                service.CreateOrder(order);
                shoppingCart.ClearCard();

                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }

    }
}
