using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Coffee", Price = 100 },
                new Product { ID = 2, Name = "Chocolate", Price = 150 },
                new Product { ID = 3, Name = "Candies", Price = 200 }
            };

            return View(products);
        }
    }
}
