using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }

        public virtual Food Food { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(ShoppingCart))]
        public string ShoppingCardId { get; set; } = null!;

        public virtual ShoppingCart ShoppingCart { get; set; } = null!;

       

      
    }
}
