using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserSessionsHistories
    {
        public Guid UserId { get; set; }

        public Guid Token { get; set; }

        [MaxLength(15)]
        public string IPAddress { get; set; } = null!;

        public bool IsLogin { get; set; }
    }
}
