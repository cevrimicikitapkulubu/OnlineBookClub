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

                context.Database.Migrate();

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

				//? ===============| USER ADD |===============
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
					SecurityStamp = Guid.NewGuid().ToString("D"),
                    AccessFailedCount = 0,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = false

				};

                if (!context.Users.Any(x => x.UserName == user.UserName))
                {
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "ExamplePass01&A");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<AppUser, AppRole, OnlineBookClubContext>(context);
                    await userStore.CreateAsync(user);
                }

                UserManager<AppUser> _userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>(); //! Burada sorun var, User'ı alamıyor.
				AppUser _user = await _userManager.FindByNameAsync(user.UserName);

                List<string> userRoles = new List<string> { "Super_Admin", "Teacher" };

                foreach (var role in userRoles)
                {
                    await _userManager.AddToRoleAsync(_user, role);
                }

                //? ===============| END of User Add |===============

                //? ===============| City ADD |===============

                foreach (var city in context.Cities.ToList())
                {
                    context.Cities.Remove(city);
                }

                List<string> cities = new List<string> { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Sivas", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };

                foreach (var city in cities)
                {
                    await context.AddAsync(city);
                }


                //? ===============| END of City Add |===============

                //? ===============| City ADD |===============

                // Departmanlar, İlçeler, Leveller, 2 Adet Event, Schools, UserAchievements

                //context.Database.ExecuteSqlRawAsync("");

				context.SaveChanges();


			}



		}
    }
}
