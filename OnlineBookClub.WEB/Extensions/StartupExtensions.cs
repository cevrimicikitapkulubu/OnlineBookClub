﻿using AspNetCoreIdentityApp.CustomValidations;
using AspNetCoreIdentityApp.Localizations;
using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.Identity;

namespace AspNetCoreIdentityApp.Extentisons
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "qwertyuıopasdfghjklizxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_";

                options.Password.RequiredLength = 10;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 5;

            }).AddErrorDescriber<LocalizationIdentityErrorDescriber>()
                .AddPasswordValidator<PasswordValidator>()
                .AddUserValidator<UserValidator>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<OnlineBookClubContext>();
        }
    }
}
