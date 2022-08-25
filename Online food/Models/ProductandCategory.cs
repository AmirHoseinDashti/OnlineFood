using System.Collections.Generic;

namespace Online_food.Models
{
    public class ProductandCategory
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
