using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Achievement
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Title { get; set; } = null!;

        [MaxLength(78)]
        public string? Image {  get; set; } = "Default_AchievementImage.webp";

        public Int16? EventCount { get; set; } = 1;

        public byte LevelId { get; set; }


        //?=========> REFERANCES

        public virtual Level Level { get; set; }
    }
}
