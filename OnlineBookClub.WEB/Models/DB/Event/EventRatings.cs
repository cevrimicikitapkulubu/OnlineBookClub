using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventRatings
    {
        [Key]
        public virtual Event Event { get; set; }
        [Key]
        public int UserId { get; set; }
        [Range(1,5)]
        public short Rating { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; }= DateTimeOffset.Now;
    }
}
