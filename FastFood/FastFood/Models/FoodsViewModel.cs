using FastFood.Data.Models;

namespace FastFood.Models
{
    public class FoodsViewModel
    {
        public IEnumerable<Food> Foods { get; set; } = null!;
        public string CurrentCategory { get; set; }=null!;
    }
}
