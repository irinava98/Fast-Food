using FastFood.Data.Models;

namespace FastFood.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> Categories { get; }
    }
}
