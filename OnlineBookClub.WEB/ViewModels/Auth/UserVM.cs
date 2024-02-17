using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Identity;
using OnlineBookClub.WEB.Models.DB.Const;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.ViewModels.Auth
{
    public class UserVM
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [MaxLength(48)]
        public string? Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string? Lastname { get; set; } = null!;

        [MaxLength(78)]
        public string? ProfilePicture { get; set; }

        public Department? Department { get; set; }

        public bool? Gender { get; set; }

        public School? School { get; set; }

        [MaxLength(8)]
        public string? SchoolNo { get; set; }

        public Level? Level { get; set; }

        public short? Point { get; set; }
    }
}
