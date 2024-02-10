using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class Event
    {
        public int Id { get; set; }

        [MaxLength(13)]
        public string ISBN { get; set; } = null!;

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public DateTimeOffset StartDate { get; set; }

        public virtual School School { get; set; }

        public virtual Location Location { get; set; }

        //!-- AUDIT COLUMNS

        public bool IS_ACTIVE { get; set; }
        public bool IS_DELETED { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; }
        public int CREATED_USER_ID { get; set; }
        public DateTimeOffset MODIFIED_DATE { get; set; }
        public int MODIFIED_USER_ID { get; set; }
    }
}
