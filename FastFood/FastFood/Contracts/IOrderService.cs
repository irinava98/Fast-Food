using FastFood.Data.Models;

namespace FastFood.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
}
