using FastFood.Contracts;
using FastFood.Data.Models;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> Categories => new List<Category>()
        {
            new Category{ CategoryName = "Vegetarian", Description="All vegetarian foods"},
            new Category {CategoryName = "Non-Vegetarian", Description="All non-vegetarian foods"}
        };
    }
}
