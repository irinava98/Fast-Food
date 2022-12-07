namespace FastFood.Models
{
    public class FoodDetailsViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LongDescription { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
