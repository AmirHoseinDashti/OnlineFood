using System.Collections.Generic;

namespace Online_food.Models.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public pagingInfo PagingInfo { get; set; }
    }
}
