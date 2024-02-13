using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.Identity;

namespace AspNetCoreIdentityApp.CustomValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();

            if (int.TryParse(user.UserName[0].ToString()!, out _))
            {
                errors.Add(new()
                {
                    Code = "UserNamecontainFirstLetterDigit",
                    Description = "Kullanıcı adı sayısal karakter ile başlayamaz."
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
