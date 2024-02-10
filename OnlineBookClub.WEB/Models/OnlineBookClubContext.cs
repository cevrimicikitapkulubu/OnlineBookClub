using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Models
{
    public class OnlineBookClubContext:IdentityDbContext<AppUser, AppRole, string>
    {
        public OnlineBookClubContext(DbContextOptions<OnlineBookClubContext> options) : base(options) { }

        //!---------------------| AUTH |---------------------



        //!---------------------| CONST |---------------------

        DbSet<Achievement> Achievements { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Level> Levels { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<School> Schools { get; set; }
        // UserAchievement Eklenecek

        //!---------------------| EVENT |---------------------

    }
}
