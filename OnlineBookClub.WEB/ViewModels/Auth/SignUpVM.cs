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
        [Required(ErrorMessage = "The 'Username' cannot be left empty.")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "The 'Email' cannot be left empty.")]
        [EmailAddress(ErrorMessage = "The Email you entered is incorrect!")]
        public string Email { get; set; }

        [DisplayName("Phone")]
        [MaxLength(11)]
        [Required(ErrorMessage = "The 'Phone' cannot be left empty.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "The 'Password' cannot be left empty.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("New Password Confirm")]
        [Required(ErrorMessage = "The 'Password Confirm' cannot be left empty.")]
        [Compare(nameof(Password), ErrorMessage = "The Passwords you entered do not match.")]
        [MinLength(10, ErrorMessage = "Your password must be a minimum of 10 characters.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }
}
