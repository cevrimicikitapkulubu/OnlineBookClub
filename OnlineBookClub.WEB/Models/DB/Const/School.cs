using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class School
    {
        public short Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
        public virtual District District { get; set; }
    }
}
