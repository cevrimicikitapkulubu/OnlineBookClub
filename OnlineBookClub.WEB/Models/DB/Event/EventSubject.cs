using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventSubject
    {
        public Event EventId { get; set; }
        public byte RowNumber { get; set; }
        [MaxLength(512)]
        public string Question { get; set; }

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }
        [DefaultValue(false)]
        public bool IS_DELETED { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.Now;
        public int CREATED_USER_ID { get; set; }
        public DateTimeOffset MODIFIED_DATE { get; set; }
        public int MODIFIED_USER_ID { get; set; }

    }
}
