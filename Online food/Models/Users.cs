using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_food.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DisplayName("نام و نام خانوداگی")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(15)]
        [DisplayName("تلفن همراه")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100)]
        [DisplayName("استان و شهر")]
        public string Address { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100)]
        [DisplayName("پلاک")]
        public string Plaque { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [StringLength(10, ErrorMessage = "کد پستی باید 10 رقمی باشد.", MinimumLength = 10)]
        [DisplayName("کدپستی")]
        public string Postalcode { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        [DisplayName("وضعیت ادمین")]
        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
