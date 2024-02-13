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
        [Required(ErrorMessage = "The 'Email' cannot be left empty.")]
        [EmailAddress(ErrorMessage = "The Email you entered is incorrect!")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "The 'Password' cannot be left empty.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
