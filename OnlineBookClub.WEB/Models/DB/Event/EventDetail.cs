using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventDetail
    {
        [Key]
        public int EventId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; } = null!;

    }
}
