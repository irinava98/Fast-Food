using FastFood.Contracts;
using FastFood.Data;
using FastFood.Data.Models;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;

        }
        public IEnumerable<Category> Categories => context.Categories;

       
    }
}
