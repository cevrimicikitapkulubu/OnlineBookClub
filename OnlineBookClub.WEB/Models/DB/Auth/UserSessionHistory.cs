using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserSessionHistory
    {
        [Key]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        public string Token { get; set; } = null!;

        [MaxLength(15)]
        public string IPAddress { get; set; } = null!;

        public bool IsLogin { get; set; }

        //?=========> REFERANCES

        public virtual IdentityUser User { get; set; }
    }
}
