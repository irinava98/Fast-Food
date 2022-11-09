using System.ComponentModel.DataAnnotations;

namespace FastFood.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public virtual ICollection<Food> Foods { get; set; }=new List<Food>();
    }
}
