using OnlineBookClub.WEB.Models.DB.Auth;
using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventRequirement
    {
        public virtual Event Event { get; set; }
        public virtual School School { get; set; }
        public virtual Department Department { get; set; }
        public virtual UserRole UserRole { get; set; }
        //public bool Gender { get; set; } // TİPİ NE OLUCAK?

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