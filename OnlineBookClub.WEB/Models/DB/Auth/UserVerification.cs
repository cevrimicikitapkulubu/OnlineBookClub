using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserVerification
    {
        [Key]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        public string GUID { get; set; }

        [DefaultValue(false)]
        public bool IsConfirmed { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public DateTimeOffset? ConfirmedDate { get; set; }

        public DateTimeOffset CREATE_DATE { get; set; } = DateTimeOffset.UtcNow;

        //?=========> REFERANCES

        public virtual IdentityUser User { get; set; }

    }
}
