using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Helpers;
using MiniStore.Models;
using MiniStore.ViewModels;

namespace MiniStore.Controllers;

public class CartController : Controller
{
    private const string CartKey = "Cart";
    private readonly IProductRepository _products;

    public CartController(IProductRepository products)
    {
        _products = products;
    }

    private List<CartItem> GetCart() =>
        HttpContext.Session.GetObject<List<CartItem>>(CartKey) ?? new List<CartItem>();

    private void SaveCart(List<CartItem> cart) =>
        HttpContext.Session.SetObject(CartKey, cart);

    public IActionResult Index()
    {
        return View(new CartViewModel { Items = GetCart() });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(int id, int quantity = 1, string? returnUrl = null)
    {
        var product = _products.GetById(id);
        if (product is null) return NotFound();

        var cart = GetCart();
        var item = cart.FirstOrDefault(i => i.ProductId == id);

        if (item is null)
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Quantity = Math.Max(1, quantity)
            });
        }
        else
        {
            item.Quantity += Math.Max(1, quantity);
        }

        SaveCart(cart);
        TempData["Message"] = $"تمت إضافة «{product.Name}» إلى السلة";

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Products");
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Update(int id, int quantity)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(i => i.ProductId == id);

        if (item is not null)
        {
            if (quantity <= 0) cart.Remove(item);
            else item.Quantity = quantity;
            SaveCart(cart);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var cart = GetCart();
        cart.RemoveAll(i => i.ProductId == id);
        SaveCart(cart);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        HttpContext.Session.Remove(CartKey);
        return RedirectToAction(nameof(Index));
    }
}