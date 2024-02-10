//using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.Identity
{
    public class User
    {
        public int ID { get; set; }

        [MaxLength(48)]
        public string Firstname { get; set; } = null!;

        [MaxLength(48)]
        public string Surname { get; set; } = null!;

        [MaxLength(24)]
        public string Username { get; set; } = null!;

        [MaxLength(320)]
        public string Email { get; set; } = null!;

        [MaxLength(11)]
        public string Phone { get; set; } = null!;

        //virtual Department DepartmentID {  get; set; }

        //virtual UserRole UserRoleID {  get; set; }

        //Gender Gender { get; set; }

        public short SchoolID { get; set; }

        [MaxLength(8)]
        public string? SchoolNo { get; set; }

        public byte? Level { get; set; }

        public short? Point { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
