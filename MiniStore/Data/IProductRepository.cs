using MiniStore.Models;

namespace MiniStore.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int? categoryId = null, string? search = null);
        Product? GetById(int id);
    }
}
