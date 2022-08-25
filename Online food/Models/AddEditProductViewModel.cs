using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_food.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [StringLength(27, ErrorMessage = "نام غذا باید کوچکتر از 5 و بزرگ تر از 27 کاراکتر نباشد.", MinimumLength = 5)]
        [DisplayName("نام غذا")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [StringLength(97, ErrorMessage = "توضیخات باید کوچکتر از 10 و بزرگ تر از 97 کاراکتر نباشد.", MinimumLength = 10)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DisplayName("قیمت")]
        public int Price { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DisplayName("تعداد")]
        public int QuantityInStock { get; set; }

        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید.")]
        [DisplayName("تصویر غذا")]
        public IFormFile Image { get; set; }

        public List<Category> Categories { get; set; }
    }
}
