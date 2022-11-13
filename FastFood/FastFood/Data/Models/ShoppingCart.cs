using System.ComponentModel.DataAnnotations;

namespace FastFood.Data.Models
{
    public class ShoppingCart
    {
        [Key]
        [Required]
        public string Id { get; set; } = null!;

        public virtual ICollection<ShoppingCartItem> Items { get; set; }= new HashSet<ShoppingCartItem>();
    }
}
