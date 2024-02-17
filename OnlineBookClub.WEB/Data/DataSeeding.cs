﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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

                if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {

                    context.Database.Migrate();

                    //? ===============| City ADD |===============


                    if (!context.Cities.Any())
                    {

                        List<string> cities = new List<string> { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Sivas", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };


                        context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Cities', RESEED, 1)");
                        foreach (var city in cities)
                        {
                            await context.Cities.AddAsync(new Models.DB.Const.City()
                            {
                                Name = city
                            });
                        }
                    }

                    //? ===============| END of City Add |===============

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
                            context.Departments.AddAsync(new Models.DB.Const.Department()
                            {
                                Name = department
                            });
                        }
                    }




                    //? ===============| City ADD |===============

                    // Departmanlar, İlçeler, Leveller, 2 Adet Event, Schools, UserAchievements


                    if (!context.Districts.Any())
                    {
                        context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Discricts', RESEED, 1)");
                        await context.Districts.AddAsync(new Models.DB.Const.District()
                        {
                            Name = "İzmit",
                            CityId = 41
                        });
                    }

                    if (!context.Schools.Any())
                    {
                        await context.Schools.AddAsync(new Models.DB.Const.School()
                        {
                            Name = "İzmit Mesleki Teknik Anadolu Lisesi",
                            DistrictId = 1
                        });
                    }

                    await context.SaveChangesAsync();
                }
            }
		}
    }
}
