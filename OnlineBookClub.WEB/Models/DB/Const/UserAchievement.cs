using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class UserAchievement
    {
        [Key]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        public int AchievementId { get; set; }

        public int EventId { get; set; } 


        //?=========> AUDIT COLUMNS

        public DateTimeOffset? CREATED_DATE { get; set; } = DateTimeOffset.UtcNow;

        //?=========> REFERANCES

        public virtual Event.Event Event { get; set; }

        public virtual Achievement Achievement { get; set; }

    }
}
