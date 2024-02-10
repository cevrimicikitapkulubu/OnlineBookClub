using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Level
    {
        [Key]
        public byte LevelId { get; set; }
        public int ExperiencePoint { get; set; }
    }
}
