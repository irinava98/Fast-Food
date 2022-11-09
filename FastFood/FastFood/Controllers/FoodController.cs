using FastFood.Contracts;
using FastFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers
{
    public class FoodController:Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IFoodService foodService;

        public FoodController(ICategoryService categoryService, IFoodService foodService)
        {
            this.categoryService = categoryService;
            this.foodService = foodService;
        }

        public IActionResult All()
        {
            var model = new FoodsViewModel();
            model.Foods = foodService.Foods;
            model.CurrentCategory = "FoodCategory";
            return View(model);
        }
    }
}
