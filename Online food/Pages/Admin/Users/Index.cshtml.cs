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
    public class IndexModel : PageModel
    {
        private readonly Online_food.Data.OnlineFoodContext _context;

        public IndexModel(Online_food.Data.OnlineFoodContext context)
        {
            _context = context;
        }

        public IList<Models.Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
