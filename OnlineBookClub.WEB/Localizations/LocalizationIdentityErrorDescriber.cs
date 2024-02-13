using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Localizations
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"'{userName}' daha önce başka bir kullanıcı tarafından alınmıştır."
            };
            //return base.DuplicateUserName(userName);
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new()
            {
                Code = "DuplicateEmail",
                Description = $"Email '{email}' başka birisi tarafından kullanımda"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz minimum {length} uzunluğunda olmalı."
            };
            //return base.PasswordTooShort(length);
        }

        public override IdentityError PasswordMismatch()
        {
            return new()
            {
                Code = "PasswordMismatch",
                Description = "Şifreler birbiriyle uyuşmuyor."
            };
            //return base.PasswordMismatch();
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifreniz en az 1 Alfabetik Olmayan (! # & *...) karakter içermeli."
            };
            //return base.PasswordRequiresNonAlphanumeric();
        }

    }
}
