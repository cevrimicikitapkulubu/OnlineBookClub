﻿using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineBookClub.WEB.Models.DB.Event
{
    public class EventParticipants
    {
        [Key]
        public int EventId { get; set; }

        [Key]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        [AllowNull]
        [MaxLength(256)]
        public string? Description { get; set; }
        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset MODIFIED_DATE { get; set; }


        public virtual Event Event { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
