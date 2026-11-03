using MiniStore.Models;

namespace MiniStore.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll() => SeedData.Categories;
    }
}
