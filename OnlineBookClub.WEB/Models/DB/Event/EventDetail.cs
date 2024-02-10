using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventDetail
    {
        public virtual Event Event { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; } = null!;
    }
}
