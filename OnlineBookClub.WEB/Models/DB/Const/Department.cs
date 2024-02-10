using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Department
    {
        public short Id { get; set; }

        [MaxLength(48)]
        public string Name { get; set; }
    }
}
