using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class City
    {
        public Int16 Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; } = null!;

        //?=========> REFERANCES

        public virtual List<District> Districts { get; set; }
    }
}
