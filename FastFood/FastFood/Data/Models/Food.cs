using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(70)]
        public string ShortDescription { get; set; }=null!;

        [Required]
        [MaxLength(150)]
        public string LongDescription { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public bool IsPreferredFood { get; set; }

        public bool InStock {get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
