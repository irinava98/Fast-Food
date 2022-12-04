using FastFood.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Data
{
    public class DbInitializer
    {


        private static Dictionary<string, Category> categories = null!;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Vegetarian", Description="All vegetarian foods" },
                        new Category { CategoryName = "Non-Vegetarian", Description="All non-vegetarian foods" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }

        public static void Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Foods.Any())
            {
                context.AddRange
                (
                    new Food
                    {
                        Name = "Hamburger",
                        Price = 5.95M,
                        ShortDescription = "The Classic Hamburger",
                        LongDescription = "The Classic  Hamburger starts with a 100% pure beef patty seasoned with just a pinch of salt and pepper. Then, the burger is topped with a tangy pickle, chopped onions, ketchup, and mustard.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202006_0001_Hamburger_Alt_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Cheeseburger",
                        Price = 7.95M,
                        ShortDescription = "The Classic Cheeseburger",
                        LongDescription = "Our classic cheeseburger begins with a 100% pure beef burger seasoned with just a pinch of salt and pepper. The Cheeseburger is topped with a tangy pickle, chopped onions, ketchup, mustard, and a slice of melty American cheese.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202006_0003_Cheeseburger_StraightBun_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Fries",
                        Price = 3.50M,
                        ShortDescription = "Fries",
                        LongDescription = "The fries are made with premium potatoes,also these epic fries are crispy and golden on the outside and fluffy on the inside.",
                        Category = Categories["Vegetarian"],
                        ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2021/03/French-fries-b9e3e0c.jpg",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Chicken Nuggets",
                        Price = 10.95M,
                        ShortDescription = "Chicken Nuggets",
                        LongDescription = "Enjoy tender, juicy Chicken Nuggets with your favorite dipping sauces.  Chicken Nuggets are made with all white meat chicken and no artificial colors, flavors, or preservatives.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "data:image/jpeg;base64,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",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Apple Slices",
                        Price = 7.95M,
                        ShortDescription = "Apple Slices",
                        Category = Categories["Vegetarian"],
                        LongDescription = "The Apple Slices are a wholesome, tasty side made from real apples. Specially selected varieties mean our apple slices are always crisp and juicy.",
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202002_2794_AppleSlices_NoBag_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Spicy Chicken Sandwich",
                        Price = 12.95M,
                        ShortDescription = "Spicy Crispy Chicken Sandwich",
                        LongDescription = "With our Spicy Pepper Sauce topping the southern style fried chicken fillet on a toasted potato roll, this sandwich was made for those who like it crispy, juicy, tender and hot.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202012_0116_SpicyCrispyChicken_PotatoBun_832x472:product-header-desktop?product-header-desktop&wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Onion Rings",
                        Price = 5.50M,
                        ShortDescription = "Onion Rings",
                        LongDescription = "Onion rings are a cross-sectional ring of onion dipped in batter and then deep fried.",
                        Category = Categories["Vegetarian"],
                        ImageUrl = "data:image/jpeg;base64,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",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Sausage Biscuit",
                        Price = 7.95M,
                        ShortDescription = "Sausage Biscuit",
                        LongDescription = "The Sausage Biscuit is the perfect sausage breakfast sandwich, made with sizzling hot sausage on a warm buttermilk biscuit that’s topped with real butter and baked to perfection.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_201907_0062_SausageBiscuit_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Sausage Muffin with Egg",
                        Price = 10.95M,
                        ShortDescription = "Sausage Muffin with Egg",
                        LongDescription = "The Sausage Muffin with Egg features a savory hot sausage, a slice of melted American cheese, and a delicious freshly cracked egg all on a freshly toasted English muffin.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_201907_0083_SausageEggMcMuffin_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Blueberry Muffin",
                        Price = 6.50M,
                        ShortDescription = "Blueberry Muffin",
                        LongDescription = "The Blueberry Muffin recipe features a soft and fluffy muffin baked with real blueberries.",
                        Category = Categories["Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202108_6500-001_BlueberryMuffin_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Bacon, Egg & Cheese Biscuit",
                        Price = 11.95M,
                        ShortDescription = "Bacon, Egg & Cheese Biscuit",
                        LongDescription = "The Bacon, Egg & Cheese Biscuit breakfast sandwich features a warm, buttermilk biscuit brushed with real butter, thick cut smoked bacon, a fluffy folded egg, and a slice of melty American cheese.",
                        Category = Categories["Non-Vegetarian"],
                        ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202211_0085_BaconEggCheeseBiscuit_832x472:product-header-desktop?wid=830&hei=458&dpr=off",
                        InStock = true,
                        IsPreferredFood = true,
                    },
                    new Food
                    {
                        Name = "Fish Burger",
                        Price = 8.95M,
                        ShortDescription = "Fish Burger",
                        LongDescription = "This fish sandwich has fish on melty American cheese and topped with creamy sauce, all served on a soft, steamed bun.",
                        ImageUrl = "https://www.burgerking.com.my/upload/image/Product/39/Fish%20N%20Crisp%20Ala%20Carte.png",
                        InStock = true,
                        IsPreferredFood = false,
                    },
                    new Food
                    {
                        Name = "Baked Apple Pie",
                        Price = 4.95M,
                        ShortDescription = "Baked Apple Pie",
                        LongDescription = "The Baked Apple Pie recipe features 100% American-grown apples, and a lattice crust baked to perfection and topped with sprinkled sugar.",
                        Category = Categories["Vegetarian"],
                        ImageUrl = "https://i0.wp.com/www.livewellbakeoften.com/wp-content/uploads/2017/08/Mini-Apple-Pies.jpg?resize=1360%2C2040&ssl=1",
                        InStock = true,
                        IsPreferredFood = true,
                    }
                );
            }

            context.SaveChanges();
        }

        
    }
}