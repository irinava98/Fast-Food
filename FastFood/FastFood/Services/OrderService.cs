using FastFood.Contracts;
using FastFood.Data;
using FastFood.Data.Models;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {

        private readonly ApplicationDbContext context;
        private readonly ShoppingCart shoppingCart;

        public OrderService(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            context.Orders.Add(order);

            var shoppingCartItems = shoppingCart.Items;

            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    FoodId = item.Food.Id,
                    OrderId=order.Id,
                    Price=item.Food.Price

                };
                context.OrderDetails.Add(orderDetail);
            }
            context.SaveChanges();
        }
    }
}
