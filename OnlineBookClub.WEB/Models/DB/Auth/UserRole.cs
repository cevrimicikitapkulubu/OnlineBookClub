using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserRole
    {
        public int Id { get; set; }

        [MaxLength(16)]
        public string Name { get; set; } = null!;
    }
}
