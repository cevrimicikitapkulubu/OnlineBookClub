using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class SignUpVM
    {
        public SignUpVM() { }

        public SignUpVM(string userName, string email, string phone, string password, string passwordConfirm)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        [DisplayName("Username")]
        [Required(ErrorMessage = "'Kullanıcı Adı' alanı boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage ="'Kullanıcı Adı' alanı en fazla '100' karakter olabilir.")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "'Email' alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }

        [DisplayName("Okul No")]
        [MaxLength(8)]
        [Required(ErrorMessage = "'Okul Numarası alanı boş bırakılamaz.")]
        public string SchoolNo { get; set; }

        [DisplayName("Okul")]
        [Required(ErrorMessage = "'Okul' boş bırakılamaz.")]
        public short SchoolId { get; set; }

        [DisplayName("Phone")]
        [MaxLength(11,ErrorMessage ="'Telefon Numarası' alanı en fazla '11' karakter uzunluğunda olabilir.")]
        [Required(ErrorMessage = "'Telefon Numarası' alanı boş bırakılamaz.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "'Şifre' alanı boş bırakılamaz.")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("New Password Confirm")]
        [Required(ErrorMessage = "'Tekrar Şifre' alanı boş bırakılamaz.")]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler uyuşmuyor.")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğu en az '10' karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }
}
