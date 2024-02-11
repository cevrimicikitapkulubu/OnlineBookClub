using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class District
    {
        public Int16 Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; } = null!;

        public Int16 CityId { get; set; }

        //?=========> REFERANCES

        public virtual City City { get; set; }

        public virtual List<School> Schools { get; set; }
    }
}
