using MiniStore.Models;

namespace MiniStore.Data
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
    }
}
