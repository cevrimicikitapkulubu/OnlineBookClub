using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Models
{
    public class OnlineBookClubContext:IdentityDbContext<AppUser, AppRole, string>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventParticipants>().HasKey(table => new {
                table.EventId,
                table.UserId
            });

            base.OnModelCreating(builder);
        }

        public OnlineBookClubContext(DbContextOptions<OnlineBookClubContext> options) : base(options) { }

        //!---------------------| AUTH |---------------------



        //!---------------------| CONST |---------------------

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<School> Schools { get; set; }
        // UserAchievement Eklenecek

        //!---------------------| EVENT |---------------------

        public DbSet<Event> Events { get; set; }
        public DbSet<EventSubject> EventSubjects { get; set; }


    }
}
