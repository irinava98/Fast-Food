using FastFood.Contracts;
using FastFood.Data;
using FastFood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext context;

        public FoodService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Food> Foods => context.Foods.Include(c => c.Category);

        public IEnumerable<Food> PreferredFoods => context.Foods.Where(f => f.IsPreferredFood).Include(c => c.Category);

        public Food GetFoodById(int id) => context.Foods.First(f => f.Id == id);
    }
}
