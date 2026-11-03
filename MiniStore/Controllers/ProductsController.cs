using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.ViewModels;

namespace MiniStore.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository _products;
    private readonly ICategoryRepository _categories;

    public ProductsController(IProductRepository products, ICategoryRepository categories)
    {
        _products = products;
        _categories = categories;
    }

    // GET: /Products?categoryId=1&search=ماوس
    public IActionResult Index(int? categoryId, string? search)
    {
        var vm = new ProductListViewModel
        {
            Products = _products.GetAll(categoryId, search),
            Categories = _categories.GetAll(),
            SelectedCategoryId = categoryId,
            Search = search
        };
        return View(vm);
    }

    // GET: /Products/Details/3
    public IActionResult Details(int id)
    {
        var product = _products.GetById(id);
        if (product is null) return NotFound();
        return View(product);
    }
}