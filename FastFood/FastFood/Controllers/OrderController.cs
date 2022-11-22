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

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
