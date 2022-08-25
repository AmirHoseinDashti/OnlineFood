using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_food.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DisplayName("نام و نام خانوداگی")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("تلفن همراه")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("تکرار کلمه عبور")]
        public string RePassword { get; set; }

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
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("تلفن همراه")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }

        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
