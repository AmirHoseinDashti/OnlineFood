using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_food.Models
{
    public class Category
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید.")]
        [DisplayName("گروه")]
        public string Name { get; set; }

        public string Description{ get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
