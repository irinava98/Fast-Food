using FastFood.Data.Models;

namespace FastFood.Contracts
{
    public interface IFoodService
    {
        IEnumerable<Food> Foods { get; }

        IEnumerable<Food> PreferredFoods { get;}

        Food GetFoodById(int id);
    }
}
