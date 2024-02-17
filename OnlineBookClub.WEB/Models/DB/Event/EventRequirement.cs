using OnlineBookClub.WEB.Enums;
using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventRequirement
    {
        [Key]
        public int EventId { get; set; }

        public short SchoolId { get; set; }

        public short DepartmentId { get; set; }

        public byte UserRoleId { get; set; }

        public bool Gender { get; set; }

        //?=========> AUDIT COLUMNS

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }

        [DefaultValue(false)]
        public bool IS_DELETED { get; set; }

        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.Now;

        public int CREATED_USER_ID { get; set; }

        public DateTimeOffset MODIFIED_DATE { get; set; }

        public int MODIFIED_USER_ID { get; set; }

        //?=========> REFERANCES

        public virtual School School { get; set; }

        public virtual Department Department { get; set; }
    }
}