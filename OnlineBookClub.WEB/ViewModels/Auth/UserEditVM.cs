using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OnlineBookClub.WEB.Models;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class UserEditVM
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "'Kullanıcı Adı' boş bırakılamaz.")]
        [MaxLength(100)]
        public string UserName { get; set; } = null!;

        [DisplayName("Ad")]
        [Required(ErrorMessage = "'Ad' boş bırakılamaz.")]
        [MaxLength(48)]
        public string Firstname { get; set; } = null!;

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "'Soyad' boş bırakılamaz.")]
        [MaxLength(48)]
        public string Lastname { get; set; } = null!;

        [DisplayName("Okul No")]
        [Required(ErrorMessage = "'Okul No' boş bırakılamaz.")]
        [MaxLength(8)]
        public string SchoolNo { get; set; } = null!;

        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "'E-Posta' boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; } = null!;

        [DisplayName("Telefon Numarası")]
        [MaxLength(11)]
        [Required(ErrorMessage = "'Telefon Numarası' boş bırakılamaz.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [DisplayName("Profil Resmi")]
        public IFormFile? ProfilePicture { get; set; }
    }
}
