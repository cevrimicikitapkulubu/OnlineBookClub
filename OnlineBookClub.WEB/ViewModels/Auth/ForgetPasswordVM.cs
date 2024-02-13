using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class ForgetPasswordVM
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "The 'Email' cannot be left empty.")]
        [EmailAddress(ErrorMessage = "The Email you entered is incorrect!")]
        public string Email { get; set; } = null!;
    }
}
