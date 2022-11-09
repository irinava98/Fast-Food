using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ShortDescription { get; set; }=null!;

        [Required]
        public string LongDescription { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string ImageThumbnailUrl=null!;

        public bool IsPreferredFood { get; set; }

        public int InStock {get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
