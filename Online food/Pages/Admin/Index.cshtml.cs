using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_food.Data;
using Online_food.Models;

namespace Online_food.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private OnlineFoodContext _context;

        public IndexModel(OnlineFoodContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products.Include(p=> p.Item);
        }

        public void OnPost()
        {
        }
    }
}
