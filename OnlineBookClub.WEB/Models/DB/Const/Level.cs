using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Level
    {
        [Key]
        public byte LevelId { get; set; }

        public Int16 ExperiencePoint { get; set; }


        //?=========> REFERANCES

        public virtual List<Achievement> Achievements  { get; set; }

    }
}
