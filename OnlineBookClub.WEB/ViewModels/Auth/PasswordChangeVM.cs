using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class PasswordChangeVM
    {

        [DisplayName("Eski Şifre")]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğunun en az 10 karakter olması gerekli")]
        [DataType(DataType.Password)]
        public string PasswordOld { get; set; } = null!;

        [DisplayName("Yeni Şifre")]
        [Required(ErrorMessage = "Yeni Şifre boş bırakılamaz\"")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğunun en az 10 karakter olması gerekli")]
        [DataType(DataType.Password)]
        public string PasswordNew { get; set; } = null!;

        [DisplayName("Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre Tekrar boş bırakılamaz\"")]
        [Compare(nameof(PasswordNew), ErrorMessage = "Şifreler uyuşmuyor")]
        [MinLength(10, ErrorMessage = "Şifre uzunluğunun en az 10 karakter olması gerekli")]
        [DataType(DataType.Password)]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
