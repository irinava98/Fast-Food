using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Data.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext context;

        private ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Key]
        [Required]
        public string Id { get; set; } = null!;

        public virtual ICollection<ShoppingCartItem> Items { get; set; }= new HashSet<ShoppingCartItem>();


        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var context = service.GetService<ApplicationDbContext>();

            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);

            return new ShoppingCart(context) { Id = cartId };

        }

        public void AddToCart(Food food, int amount)
        {
            var shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(s => s.Food.Id == food.Id && s.ShoppingCardId==Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCardId = Id,
                    Food = food,
                    Amount = 1,

                };

                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public void RemoveFromCart(Food food)
        {
            var shoppingCartItem = context.ShoppingCartItems.SingleOrDefault(s => s.Food.Id == food.Id && s.ShoppingCardId == Id);



            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            context.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return context.ShoppingCartItems.Where(c => c.ShoppingCardId == Id).Include(s => s.Food).ToList();
        }

        public void ClearCard()
        {
            var carItems = context.ShoppingCartItems.Where(cart => cart.ShoppingCardId == Id);

            context.ShoppingCartItems.RemoveRange(carItems);

            context.SaveChanges();

        }

        public decimal GetShoppingCartTotal()
        {
            var total = context.ShoppingCartItems.Where(c => c.ShoppingCardId == Id).Select(c => c.Food.Price * c.Amount).Sum();
            return total;
        }
    }
}
