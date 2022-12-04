using FastFood.Contracts;
using FastFood.Data.Models;
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

        public IActionResult All(string category)
        {
            string _category = category;
            IEnumerable<Food> foods;


            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                foods = foodService.Foods.OrderBy(f => f.Id);
                currentCategory = "All foods";
            }
            else
            {
                if (string.Equals("Vegetarian", _category,StringComparison.OrdinalIgnoreCase))
                {
                    foods = foodService.Foods.Where(f => f.Category.CategoryName.Equals("Vegetarian")).OrderBy(f => f.Name);
                }
                else
                {
                    foods = foodService.Foods.Where(f => f.Category.CategoryName.Equals("Non-Vegetarian")).OrderBy(f => f.Name);
                }
                currentCategory = _category;
            }


            var model = new FoodsViewModel
            {
                Foods = foods,
                CurrentCategory = currentCategory
            };
           
            return View(model);
        }
    }
}
