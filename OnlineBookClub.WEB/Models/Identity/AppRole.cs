using Microsoft.AspNetCore.Identity;

namespace OnlineBookClub.WEB.Models.Identity
{
    public class AppRole:IdentityRole
    {
        public string? xyz { get; set; }
    }
}
