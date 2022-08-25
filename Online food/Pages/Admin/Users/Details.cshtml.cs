using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_food.Data;
using Online_food.Models;

namespace Online_food.Pages.Admin.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Online_food.Data.OnlineFoodContext _context;

        public DetailsModel(Online_food.Data.OnlineFoodContext context)
        {
            _context = context;
        }

        public Models.Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
