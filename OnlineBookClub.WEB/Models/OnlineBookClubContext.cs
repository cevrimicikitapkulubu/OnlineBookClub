using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.DB.User;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Models
{
	public class OnlineBookClubContext : IdentityDbContext<AppUser, AppRole, string>
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			//!========| EVENT |========

			//? EVENT PARTICIPANT

			builder.Entity<EventParticipant>().HasKey(table => new {
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

			//builder.Entity<District>()
			//    .HasOne(x => x.City)
			//    .WithMany()
			//    .OnDelete(DeleteBehavior.NoAction);

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

			//builder.Entity<School>()
			//    .HasOne(x => x.District)
			//    .WithMany()
			//    .OnDelete(DeleteBehavior.NoAction);



			base.OnModelCreating(builder);
		}

		public OnlineBookClubContext(DbContextOptions<OnlineBookClubContext> options) : base(options) { }


		//!---------------------| CONST |---------------------

		public DbSet<Achievement> Achievements { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<District> Districts { get; set; }
		public DbSet<Level> Levels { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<School> Schools { get; set; }
		public DbSet<UserAchievement> UserAchievements { get; set; }

		//!---------------------| EVENT |---------------------

		public DbSet<Event> Events { get; set; }
		public DbSet<EventDetail> EventDetails { get; set; }
		public DbSet<EventParticipant> EventParticipants { get; set; }
		public DbSet<EventRating> EventRatings { get; set; }
		public DbSet<EventRequirement> EventRequirements { get; set; }
		public DbSet<EventSubject> EventSubjects { get; set; }
		public DbSet<Location> Locations { get; set; }

		public DbSet<UserBookListType> UserBookListType { get; set; }
		public DbSet<UserBookList> UserBookLists { get; set; }
	}
}
