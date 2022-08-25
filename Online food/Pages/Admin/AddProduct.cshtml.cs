using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Online_food.Data;
using Online_food.Models;

namespace Online_food.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> SelectGroups { get; set; }

        private OnlineFoodContext _context;

        public AddProductModel(OnlineFoodContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var item = new Item()
                {
                    Price = Product.Price,
                    QuantityInStock = Product.QuantityInStock
                };
                _context.Add(item);
                _context.SaveChanges();

                var product = new Product()
                {
                    Name = Product.Name,
                    Item = item,
                    Description = Product.Description
                };
                _context.Add(product);
                _context.SaveChanges();
                product.ItemId = product.Id;
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
