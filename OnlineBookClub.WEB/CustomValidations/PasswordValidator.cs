using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.Identity;

namespace AspNetCoreIdentityApp.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainsUserName", 
                    Description = "Şifre kullanıcı adı içeremez!"
                });
            }

            if (password.ToLower().StartsWith("123"))
            {
                errors.Add(new()
                {
                    Code = "PasswordContains1234",
                    Description = "Şifre '123' ile başlayamaz."
                });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);

        }
    }
}
