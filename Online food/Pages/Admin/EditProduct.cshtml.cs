using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_food.Data;
using Online_food.Models;

namespace Online_food.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        private OnlineFoodContext _context;

        public EditProductModel(OnlineFoodContext context)
        {
            _context = context;
        }

        [BindProperty] public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> SelectGroups { get; set; }

        public List<int> GroupsProduct { get; set; }

        public void OnGet(int id)
        {
            Product = _context.Products.Include(p => p.Item).Where(p => p.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price
                }).FirstOrDefault();

            Product.Categories = _context.Categories.ToList();
            GroupsProduct = _context.CategoryToProducts.Where(c => c.ProductId == id)
                .Select(s => s.CategoryId).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.Find(Product.Id);
                var item = _context.Items.First(p => p.Id == product.ItemId);

                product.Name = Product.Name;
                product.Description = Product.Description;
                item.Price = Product.Price;
                item.QuantityInStock = Product.QuantityInStock;
                _context.SaveChanges();
                if (Product.Image?.Length > 0)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                        product.Id + ".jpg");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Product.Image.CopyTo(stream);
                    }
                }

                _context.CategoryToProducts.Where(c => c.ProductId == product.Id).ToList()
                    .ForEach(g => _context.CategoryToProducts.Remove(g));
                if (SelectGroups.Any() && SelectGroups.Count > 0)
                {
                    foreach (int selectGroup in SelectGroups)
                    {
                        _context.CategoryToProducts.Add(new CategoryToProduct()
                        {
                            CategoryId = selectGroup,
                            ProductId = product.Id
                        });
                    }
                    _context.SaveChanges();
                }
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
