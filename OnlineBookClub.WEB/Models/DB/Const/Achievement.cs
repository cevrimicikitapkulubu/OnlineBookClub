using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class Achievement
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Title { get; set; } = null!;

<<<<<<< HEAD
=======
        [MaxLength(78)]
        public string? Image {  get; set; } = "Default_AchievementImage.webp";

>>>>>>> 3abc659b2250bc3dd1c8193a123802c467214d2a
        public Int16? EventCount { get; set; } = 1;

        public byte LevelId { get; set; }


        //?=========> REFERANCES

        public virtual Level Level { get; set; }
    }
}
