using FastFood.Data.Models;

namespace FastFood.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; } = null!;

        public decimal ShoppingCartTotal { get; set; }
    }
}
