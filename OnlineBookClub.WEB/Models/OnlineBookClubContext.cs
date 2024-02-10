//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Const;

namespace OnlineBookClub.WEB.Models
{
    public class OnlineBookClubContext:DbContext
    {
        public OnlineBookClubContext(DbContextOptions<OnlineBookClubContext> options) : base(options)
        {
        }

        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
    }
}
