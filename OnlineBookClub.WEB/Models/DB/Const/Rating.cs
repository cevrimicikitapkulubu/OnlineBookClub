using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Rating
    {
        [Key]
        [Range(1, 5)]
        public byte Rate { get; set; }

        public byte Point { get; set; }
    }
}
