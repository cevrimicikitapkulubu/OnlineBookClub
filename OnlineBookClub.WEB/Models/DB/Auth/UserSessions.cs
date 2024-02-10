using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserSessions
    {
        public Guid UserId { get; set; }

        public Guid Token { get; set; }

        [MaxLength(15)]
        public string IPAddress { get; set; } = null!;

        public DateTimeOffset LoginDate { get; set; }

    }
}
