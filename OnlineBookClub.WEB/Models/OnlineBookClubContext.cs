using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Auth;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Models
{
    public class OnlineBookClubContext:IdentityDbContext<AppUser, AppRole, string>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //!========| AUTH |========

            builder.Entity<UserInfo>()
                .HasIndex(x => x.Id)
                .HasFillFactor(90);

            builder.Entity<UserInfo>()
                .HasCheckConstraint("CHK_Users_PhoneNumber", "PhoneNumber NOT LIKE '%[^0-9]%' AND LEN(PhoneNumber) = 11");

            builder.Entity<UserInfo>()
                .HasOne(x => x.Department)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Users_DepartmentID_Departments");

            builder.Entity<UserInfo>()
                .HasOne(x => x.UserRole)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserInfo>()
                .HasOne(x => x.School)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserInfo>()
                .HasOne(x => x.Level)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);



            //!========| EVENT |========

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
