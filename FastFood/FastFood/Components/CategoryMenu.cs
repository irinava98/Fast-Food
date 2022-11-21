using FastFood.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoryMenu(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.Categories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
