using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; } = null!;

        public virtual List<District> Districts { get; set; }
    }
}
