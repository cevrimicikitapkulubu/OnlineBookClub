using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class LogInVM
    {
        public LogInVM() { }

        public LogInVM(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [DisplayName("Email")]
        [Required(ErrorMessage = "'Email' alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "'Şifre' alanı boş bırakılamaz.")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
