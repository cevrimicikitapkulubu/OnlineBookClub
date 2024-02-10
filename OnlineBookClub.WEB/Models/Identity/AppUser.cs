using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.DB.Auth;

namespace OnlineBookClub.WEB.Models.Identity
{
    public class AppUser:IdentityUser
    {
        public virtual UserInfo UserId { get; set; }
    }
}
