using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Areas.Admin.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }


        public string? Email { get; set; } = null!;
        public string? Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string? Lastname { get; set; } = null!;

        public short? DepartmentId { get; set; }

        public bool? Gender { get; set; }

        public short SchoolId { get; set; }

        [MaxLength(78)]
        public string? ProfilePicture { get; set; } = "DefaultUserPicture.jpg";

        [MaxLength(8)]
        public string SchoolNo { get; set; } = null!;

        public short? Point { get; set; }


        public List<AppUser> Users { get; set; }

    }
}
