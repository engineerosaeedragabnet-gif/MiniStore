using MiniStore.Models;

namespace MiniStore.Data
{
    public static class SeedData
    {
        public static readonly List<Category> Categories = new()
        {
        new Category { Id = 1, Name = "إلكترونيات" },
        new Category { Id = 2, Name = "ملابس" },
        new Category { Id = 3, Name = "كتب" }
        };

        public static readonly List<Product> Products = new()
        {
        new Product { Id = 1, Name = "سماعة بلوتوث", Description = "سماعة لاسلكية بجودة صوت عالية وبطارية تدوم 20 ساعة.", Price = 750, CategoryId = 1, ImageUrl = "https://placehold.co/400x250?text=Headphones" },
        new Product { Id = 2, Name = "ماوس لاسلكي", Description = "ماوس مريح بدقة عالية مناسب للعمل والألعاب.", Price = 300, CategoryId = 1, ImageUrl = "https://placehold.co/400x250?text=Mouse" },
        new Product { Id = 3, Name = "تيشيرت قطن", Description = "تيشيرت قطن 100% متوفر بعدة ألوان.", Price = 250, CategoryId = 2, ImageUrl = "https://placehold.co/400x250?text=T-Shirt" },
        new Product { Id = 4, Name = "جاكيت شتوي", Description = "جاكيت دافئ مقاوم للرياح.", Price = 1200, CategoryId = 2, ImageUrl = "https://placehold.co/400x250?text=Jacket" },
        new Product { Id = 5, Name = "كتاب تعلم C#", Description = "دليل عملي للمبتدئين خطوة بخطوة.", Price = 400, CategoryId = 3, ImageUrl = "https://placehold.co/400x250?text=C%23+Book" },
        new Product { Id = 6, Name = "كتاب ASP.NET Core", Description = "بناء تطبيقات الويب الحديثة بـ MVC.", Price = 550, CategoryId = 3, ImageUrl = "https://placehold.co/400x250?text=ASP.NET" }
        };
    }
}
