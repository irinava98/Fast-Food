using FastFood.Contracts;
using FastFood.Data.Models;
using FastFood.Models;
using FastFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFoodService foodService;
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartController(IFoodService foodService, ShoppingCart shoppingCart)
        {
            this.foodService=foodService;
            this.shoppingCart=shoppingCart;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.Items= items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart=shoppingCart,
                ShoppingCartTotal=shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(int foodId)
        {
            var selectedFood=foodService.Foods.FirstOrDefault(f=>f.Id==foodId);

            if (selectedFood != null)
            {
                shoppingCart.AddToCart(selectedFood, 1);
            }

            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromShoppingCart(int foodId)
        {
            var selectedFood = foodService.Foods.FirstOrDefault(f => f.Id == foodId);
            if (selectedFood != null)
            {
                shoppingCart.RemoveFromCart(selectedFood.Id);
            }
            return RedirectToAction("Index");
        }

    }
}
