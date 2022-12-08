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

        public IActionResult All(FoodsViewModel model,string category)
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
                    currentCategory = "Vegetarian";
                    foods = foodService.Foods.Where(f => f.Category?.CategoryName==currentCategory).OrderBy(f => f.Name);
                }
                else
                {
                    currentCategory = "Non-Vegetarian";
                    foods = foodService.Foods.Where(f => f.Category?.CategoryName==currentCategory).OrderBy(f => f.Name);
                }
                currentCategory = _category;
            }


            model = new FoodsViewModel
            {
                Foods = foods,
                CurrentCategory = currentCategory
            };
           
            return View(model);
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                foods = foodService.Foods.OrderBy(f => f.Id);
            }
            else
            {
                foods = foodService.Foods.Where(f => f.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Food/All.cshtml");
        }

        public ViewResult Details(int foodId)
        {
            var food = foodService.Foods.FirstOrDefault(f => f.Id == foodId);
            if (food == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(food);
        }
    }
}
