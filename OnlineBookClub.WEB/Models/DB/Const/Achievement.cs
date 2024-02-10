using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Achievement
    {
        public int Id { get; set; }

        [MaxLength(16)]
        public string Title { get; set; }
        public int EventCount { get; set; }
        public virtual Level Level { get; set; }
    }
}
