using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserPassword
    {
        [MaxLength(450)]
        public string UserId { get; set; }

        [MaxLength(256)]
        public string PasswordHash { get; set; } = null!;

        [MaxLength(256)]
        public string PasswordSalt { get; set; } = null!;
    }
}
