using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventParticipants
    {
        [Key]
        public virtual Event Event { get; set; }
        public int UserId { get; set; }
        [AllowNull]
        public virtual Rating Rating { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset MODIFIED_DATE { get; set; }
    }
}
