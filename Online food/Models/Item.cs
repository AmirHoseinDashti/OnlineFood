using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_food.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int QuantityInStock { get; set; }
        public Product Product { get; set; }

    }
}
