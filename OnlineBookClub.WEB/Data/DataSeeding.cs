using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Data
{
    public static class DataSeeding
    {
        public static async void Seed(IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<OnlineBookClubContext>()!;

				//? ===============| ROLE ADD |===============
				List<string> roles = new List<string> 
                {
                    "Admin",
                    "Super_Admin",
                    "Teacher",
                    "User"
                };

                foreach (var role in context.Roles.ToList())
                {
                    context.Roles.Remove(role);

				}

                foreach (var role in roles)
				{
					var roleStore = new RoleStore<IdentityRole>(context);

					if (!context.Roles.Any(r => r.Name == role))
					{
						roleStore.CreateAsync(new IdentityRole(role));
					}
				}

                //? ===============| END of Role Add |===============

                var user = new AppUser
                {
                    CREATED_DATE = DateTime.UtcNow,
                    Email = "cevrimicikitapkulubu@gmail.com",
                    Firstname = "Fatih",
                    Lastname = "Şahinbaş",
                    NormalizedEmail = "cevrimicikitapkulubu@gmail.com".ToUpper(),
                    NormalizedUserName = "FSAHİNBAS",
                    UserName = "FSahinbas",
                    PhoneNumber = "05123456789",
                    SchoolId = 1,
					SecurityStamp = Guid.NewGuid().ToString("D")

				};

                if (!context.Users.Any(x => x.UserName == user.UserName))
                {
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "ExamplePass01&A");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<AppUser>(context);
                    userStore.CreateAsync(user);
                }

                UserManager<AppUser> _userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
                AppUser _user = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRolesAsync(_user, new List<string> { "Super_Admin", "Teacher" });

                context.SaveChanges();


			}



		}
    }
}
