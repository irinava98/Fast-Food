using FastFood.Data.Models;

namespace FastFood.Contracts
{
    public interface IFoodService
    {
        IEnumerable<Food> Foods { get; set; }

        IEnumerable<Food> PreferredFoods { get; set; }

        Food GetFoodById(int id);
    }
}
