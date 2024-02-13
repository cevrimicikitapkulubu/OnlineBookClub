using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class ResetPasswordVM
    {
        [DisplayName("New Password")]
        [Required(ErrorMessage = "'Yeni Şifre' alanı boş bırakılamaz.")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DisplayName("New Password Confirm")]
        [Required(ErrorMessage = "'Tekrar Şifre' alanı boş bırakılamaz.")]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler uyuşmumyor")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; } = null!;
    }
}
