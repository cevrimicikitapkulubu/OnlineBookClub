using Microsoft.AspNetCore.Identity;

namespace OnlineBookClub.WEB.Models.Identity
{
    public class AppUser:IdentityUser
    {
        public string? xyz { get; set; }
    }
}
