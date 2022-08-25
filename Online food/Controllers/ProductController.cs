using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_food.Data;
using Online_food.Models;

namespace Online_food.Controllers
{
    public class ProductController : Controller
    {
        private OnlineFoodContext _context;

        public ProductController(OnlineFoodContext context)
        {
            _context = context;
        }

        [Route("/Group/{id}/{name}")]
        public IActionResult ShowProduct(int id , string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts
                .Where(c=> c.CategoryId == id)
                .Include(p => p.Product.Item )
                .Select(c=> c.Product)
                .ToList();

            var category = _context.Categories
                .Include(p => p.CategoryToProducts)
                .ToList();

            var model = new ProductandCategory()
            {
                Products = products,
                Categories = category
            };

            return View(model);
        }
    }
}
