using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(13)]
        public string ISBN { get; set; } = null!;

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        public DateTimeOffset StartDate { get; set; }

        public virtual School School { get; set; }

        public virtual Location Location { get; set; }

        //!-- AUDIT COLUMNS

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }

        [DefaultValue(false)]
        public bool IS_DELETED { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.Now;
        public int CREATED_USER_ID { get; set; }
        public DateTimeOffset MODIFIED_DATE { get; set; }
        public int MODIFIED_USER_ID { get; set; }


        public virtual List<EventParticipants> EventParticipants { get; set; }
        public virtual List<EventRatings> EventRatings { get; set; }
        //public virtual List<EventRequirement> EventRequirements { get; set; }
    }
}
