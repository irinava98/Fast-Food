using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;


        public int FoodId {get; set; }

        public virtual Food Food { get; set; } = null!;
    }
}
