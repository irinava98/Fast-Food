using FastFood.Contracts;
using FastFood.Data.Models;

namespace FastFood.Services
{
    public class FoodService : IFoodService
    {
        public IEnumerable<Food> Foods { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<Food> PreferredFoods { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Food GetFoodById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
