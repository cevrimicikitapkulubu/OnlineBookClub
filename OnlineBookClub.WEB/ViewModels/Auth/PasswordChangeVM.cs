using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class PasswordChangeVM
    {

        [DisplayName("Old Password")]
        [Required(ErrorMessage = "The 'Password' cannot be left empty.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string PasswordOld { get; set; } = null!;

        [DisplayName("New Password")]
        [Required(ErrorMessage = "The 'New Password' cannot be left empty.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string PasswordNew { get; set; } = null!;

        [DisplayName("New Password Confirm")]
        [Required(ErrorMessage = "The 'Password Confirm' cannot be left empty.")]
        [Compare(nameof(PasswordNew), ErrorMessage = "The Passwords you entered do not match.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
