using MiniStore.Models;

namespace MiniStore.Data
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll(int? categoryId = null, string? search = null)
        {
            var query = SeedData.Products.AsEnumerable();

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            return query.Select(WithCategory).ToList();
        }

        public Product? GetById(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.Id == id);
            return product is null ? null : WithCategory(product);
        }

        private static Product WithCategory(Product p)
        {
            p.Category = SeedData.Categories.FirstOrDefault(c => c.Id == p.CategoryId);
            return p;
        }
    }
}
