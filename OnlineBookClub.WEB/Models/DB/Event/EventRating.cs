using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventRating
    {
        public int EventId  { get; set; }

        public int UserId { get; set; }

        [Range(1,5)]
        public short Rating { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? CREATED_DATE { get; set; }= DateTimeOffset.UtcNow;

        //?=========> REFERANCES

        public virtual Event Event { get; set; }
    }
}
