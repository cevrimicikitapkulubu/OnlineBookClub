using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.DB.Event;
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

                if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.Exists())
                {
                    context.Database.Migrate();
                }

                //? ===============| City ADD |===============


                if (!context.Cities.Any())
                {

                    //List<string> cities = new List<string> { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Sivas", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };


                    await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 1)");
                    foreach (var city in cities)
                    {
                        await context.Cities.AddAsync(new Models.DB.Const.City());
                        List<string> cities = new List<string> { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };


                        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Cities', RESEED, 1)");
                        foreach (var city in cities)
                        {
                            context.Cities.Add(new Models.DB.Const.City()
                            {
                                Name = city
                            });
                        }
                    }

                    //? ===============| END of City Add |===============

                    //? ===============| District ADD |===============


                    if (!context.Districts.Any())
                    {
                        await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Districts', RESEED, 1)");
                        await context.Districts.AddAsync(new Models.DB.Const.District());
                        //await context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Districts', RESEED, 1)");

                        context.Districts.Add(new District()
                        {
                            Name = "İzmit",
                            CityId = 41
                        });
                    }

                    //? ===============| END of District Add |===============

                    //? ===============| Department ADD |===============

                    List<string> departments = new List<string>()
                {
                    "Bilişim Teknolojileri",
                    "Elektrik-Elektronik Teknolojisi",
                    "Endüstriyel Otomasyon Teknolojileri",
                    "Kimya Teknolojisi",
                    "Makine ve Tasarım Teknolojisi",
                    "Metal Teknolojileri",
                    "Mobilya ve İç Mekan Tasarımı",
                    "Motorlu Araçlar Teknolojisi"
                };


                    if (!context.Departments.Any())
                    {

                        foreach (var department in departments)
                        {
                            await context.Departments.AddAsync(new Models.DB.Const.Department()
                            {
                                Name = department
                            });
                        }
                    }


                    //? ===============| END of Department Add |===============

                    //? ===============| School ADD |===============
                    if (!context.Schools.Any())
                    {

                        await context.Schools.AddAsync(new Models.DB.Const.School());

                        context.Schools.Add(new Models.DB.Const.School()

                        {
                            Name = "İzmit Mesleki Teknik Anadolu Lisesi",
                            DistrictId = 1
                        });
                    }

                    //? ===============| END of School Add |===============

                    //? ===============| Location ADD |===============

                    if (!context.Locations.Any())
                    {
                        await context.Locations.AddAsync(new Location());

                        context.Locations.Add(new Location()

                        {
                            IsOnline = false,
                            Title = "Okul Kütüphanesi"
                        });
                    }
                    //? ===============| END of Location Add |===============


                    await context.SaveChangesAsync();

                    //? ===============| Level ADD |===============

                    if (!context.Levels.Any())
                    {
                        context.Levels.AddRange(
                        new Models.DB.Const.Level()
                        {
                            LevelId = 1,
                            ExperiencePoint = 10,
                        },
                        new Models.DB.Const.Level()
                        {
                            LevelId = 2,
                            ExperiencePoint = 25,
                        },
                        new Models.DB.Const.Level()
                        {
                            LevelId = 3,
                            ExperiencePoint = 40,
                        },
                        new Models.DB.Const.Level()
                        {
                            LevelId = 4,
                            ExperiencePoint = 70,
                        },
                        new Models.DB.Const.Level()
                        {
                            LevelId = 5,
                            ExperiencePoint = 100,
                        }
                        );
                    }

                    //? ===============| END of Level Add |===============

                    //? ===============| Rating ADD |===============

                    if (!context.Ratings.Any())
                    {
                        context.Ratings.AddRange(
                        new Rating()
                        {
                            Rate = 1,
                            Point = 10
                        },
                        new Rating()
                        {
                            Rate = 2,
                            Point = 20
                        },
                        new Rating()
                        {
                            Rate = 3,
                            Point = 30
                        },
                        new Rating()
                        {
                            Rate = 4,
                            Point = 40
                        },
                        new Rating()
                        {
                            Rate = 5,
                            Point = 50
                        }
                        );
                    }

                    //? ===============| END of Rating Add |===============

                    //? ===============| Achievement ADD |===============

                    if (!context.Achievements.Any())
                    {
                        context.Achievements.AddRange(
                        new Achievement()
                        {
                            LevelId = 1,
                            EventCount = 1,
                            Title = "İlk Etkinliğine giriş yap."
                        },
                        new Achievement()
                        {
                            LevelId = 1,
                            EventCount = 5,
                            Title = "5 Etkinliğe katıl.",
                            Image = "FiveEventJoin.jpg"
                        }
                        );
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
