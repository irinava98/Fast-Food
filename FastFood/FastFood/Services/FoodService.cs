using FastFood.Contracts;
using FastFood.Data.Models;

namespace FastFood.Services
{
    public class FoodService : IFoodService
    {
        private readonly ICategoryService categoryService= new CategoryService();

        public IEnumerable<Food> Foods => new List<Food>
        {
            new Food
            {
                Name= "Cheeseburger",
                Price = 3.90M,
                ShortDescription="100% beef, Cheddar cheese, ketchup, mustard, pickles, onion",
                LongDescription="Our simple, classic cheeseburger begins with a 100% pure beef burger seasoned with just a pinch of salt and pepper. It contains no artificial flavors, preservatives or added colors from artificial sources.",
                Category=categoryService.Categories.Last(),
                ImageUrl="https://res.cloudinary.com/sonic-drive-in/image/upload/c_fit,w_400,h_400,dpr_2,f_auto,q_auto/v1632936124/oa_menu/products/menuproduct_Cheeseburger_Plain.png",
                InStock=true,
                IsPreferredFood=true,

            },
            new Food
            {
                Name="Hamburger",
                Price=3.20M,
                ShortDescription="100% pure beef patty seasoned with just a pinch of salt and pepper",
                LongDescription="The Classic Hamburger starts with a 100% pure beef patty seasoned with just a pinch of salt and pepper. Then, the burger is topped with a tangy pickle, chopped onions, ketchup, and mustard.",
                Category =categoryService.Categories.Last(),
                ImageUrl="https://res.cloudinary.com/sonic-drive-in/image/upload/c_fit,w_600,h_600,dpr_2,f_auto,q_auto/v1632936124/oa_menu/products/menuproduct_Cheeseburger_Plain.png",
                InStock =true,
                IsPreferredFood=true
            },
            new Food
            {
                Name="Fries",
                Price=2.50M,
                ShortDescription="tasty fries",
                LongDescription="The fries are made with premium potatoes",
                Category=categoryService.Categories.First(),
                ImageUrl="https://www.seriouseats.com/thmb/Il7mv9ZSDh7n0cZz3t3V-28ImkQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__2018__04__20180309-french-fries-vicky-wasik-15-5a9844742c2446c7a7be9fbd41b6e27d.jpg",
                InStock=true,
                IsPreferredFood=true
            }
        };
        public IEnumerable<Food> PreferredFoods { get; } = null!;
        public Food GetFoodById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
