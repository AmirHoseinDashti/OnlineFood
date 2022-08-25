using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_food.Data;

namespace Online_food.Components
{
    public class ProductGroupComponent:ViewComponent
    {
        private OnlineFoodContext _context;

        public ProductGroupComponent(OnlineFoodContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> Invokeasync()
        {
            return View("/Views/Product/ShowProduct.cshtml");
        }
    }
}
