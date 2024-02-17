using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventSubject
    {
        public int Id {  get; set; } 

        public int EventId { get; set; }

        public byte? RowNumber { get; set; }

        [MaxLength(512)]
        public string Question { get; set; }

        //?=========> AUDIT COLUMNS

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }

        [DefaultValue(false)]
        public bool IS_DELETED { get; set; }

        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.UtcNow;

        public string CREATED_USER_ID { get; set; }

        public DateTimeOffset? MODIFIED_DATE { get; set; }

        public string? MODIFIED_USER_ID { get; set; }

        //?=========> REFERANCES

        public virtual Event Event { get; set; }

    }
}
