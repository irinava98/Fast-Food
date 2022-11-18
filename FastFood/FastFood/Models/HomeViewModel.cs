using FastFood.Data.Models;

namespace FastFood.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Food> PreferredFoods { get; set; }= new List<Food>();
    }
}
