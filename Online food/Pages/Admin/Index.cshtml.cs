using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_food.Data;
using Online_food.Models;
using Online_food.Models.ViewModels;

namespace Online_food.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private OnlineFoodContext _context;

        public IndexModel(OnlineFoodContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductsViewModel ProductsViewModel { get; set; }
        public void OnGet(int pageId = 1)
        {
            ProductsViewModel = new ProductsViewModel()
            {
                Products = _context.Products.Include(p => p.Item),
            };
            StringBuilder param = new StringBuilder();
            param.Append("/Product?pageId=:");
            var Count = ProductsViewModel.Products.Count();
            ProductsViewModel.PagingInfo = new pagingInfo()
            {
                CurrentPage = pageId,
                ItemPage = 2,
                TotalItems = Count,
                UrlParam = param.ToString()
            };
            ProductsViewModel.Products = ProductsViewModel.Products.OrderBy(u=> u.Name).Skip((pageId -1 ) * 2).Take(2).ToList();
        }

        public void OnPost()
        {
        }
    }
}
