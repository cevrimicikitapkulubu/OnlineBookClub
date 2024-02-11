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

            //? USER INFO

            builder.Entity<UserInfo>()
                .HasIndex(x => x.Id)
                .HasFillFactor(100);

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

            //? USER PASSWORD

            builder.Entity<UserPassword>()
                .HasIndex(x => x.UserId)
                .HasFillFactor(100);

            builder.Entity<UserPassword>()
                .HasOne(x => x.UserId)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //? USER SESSION HISTORY

            builder.Entity<UserSessionHistory>()
                .HasIndex(x => x.UserId)
                .HasFillFactor(100);

            builder.Entity<UserSessionHistory>()
                .HasOne(x => x.UserId)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //? USER SESSION

            builder.Entity<UserSession>()
                .HasIndex(x => x.UserId)
                .HasFillFactor(100);

            builder.Entity<UserSession>()
                .HasOne(x => x.UserId)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //? USER VERIFICATION

            builder.Entity<UserVerification>()
                .HasIndex(x => x.UserId)
                .HasFillFactor(100);

            builder.Entity<UserVerification>()
                .HasOne(x => x.UserId)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);


            //!========| EVENT |========

            //? EVENT PARTICIPANT

            builder.Entity<EventParticipants>().HasKey(table => new {
                table.EventId,
                table.UserId
            });


            //!========| CONST |========

            //? ACHIEVEMENT

            builder.Entity<Achievement>()
                .HasIndex(x => x.Id)
                .HasFillFactor(70);

            //? CITY

            builder.Entity<Achievement>()
                .HasIndex(x => x.Id)
                .HasFillFactor(70);

            //? DEPARTMENT

            builder.Entity<Department>()
                .HasIndex(x => x.Id)
                .HasFillFactor(100);

            //? DISTRICT

            builder.Entity<District>()
                .HasIndex(x => x.Id)
                .HasFillFactor(70);

            builder.Entity<District>()
                .HasOne(x => x.City)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //? LEVEL

            builder.Entity<Level>()
                .HasIndex(x => x.LevelId)
                .HasFillFactor(70);

            //? RATING

            builder.Entity<Rating>()
                .HasIndex(x => x.Rate)
                .HasFillFactor(70);

            //? SCHOOL

            builder.Entity<School>()
                .HasIndex(x => x.Id)
                .HasFillFactor(70);

            builder.Entity<School>()
                .HasOne(x => x.District)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);



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
