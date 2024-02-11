﻿using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.Identity
{
    public class AppUser:IdentityUser
    {
        [MaxLength(48)]
        public string Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string Lastname { get; set; } = null!;

        public Int16 DepartmentId { get; set; }

        public bool Gender { get; set; }

        public short SchoolId { get; set; }

        [MaxLength(8)]
        public string? SchoolNo { get; set; }

        public byte? LevelId { get; set; }

        public short? Point { get; set; }

        //?=========> AUDIT COLUMNS

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }

        [DefaultValue(false)]
        public bool IS_DELETED { get; set; }

        public DateTimeOffset CREATED_DATE { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? MODIFIED_DATE { get; set; }

        //?=========> REFERANCES

        public virtual Department Department { get; set; }

        public virtual School School { get; set; }

        public virtual Level Level { get; set; }
    }
}
