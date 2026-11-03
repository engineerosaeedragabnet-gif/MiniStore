using MiniStore.Models;

namespace MiniStore.ViewModels;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public int? SelectedCategoryId { get; set; }
    public string? Search { get; set; }
}