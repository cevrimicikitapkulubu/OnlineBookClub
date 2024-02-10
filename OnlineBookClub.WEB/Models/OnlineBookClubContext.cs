using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Models
{
    public class OnlineBookClubContext:IdentityDbContext<AppUser, AppRole, string>
    {
        public OnlineBookClubContext(DbContextOptions<OnlineBookClubContext> options) : base(options) { }

        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
    }
}
