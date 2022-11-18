using FastFood.Contracts;
using FastFood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FastFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodService foodService;

        public HomeController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredFoods = foodService.PreferredFoods
            };
           return View(homeViewModel);
        }
            
    }
}

