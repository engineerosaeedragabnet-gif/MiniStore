using MiniStore.Models;

namespace MiniStore.ViewModels;

public class CartViewModel
{
    public List<CartItem> Items { get; set; } = new();
    public decimal GrandTotal => Items.Sum(i => i.Total);
    public int TotalQuantity => Items.Sum(i => i.Quantity);
}