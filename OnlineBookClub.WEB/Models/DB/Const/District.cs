using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class District
    {
        public int Id { get; set; } // Id - DistrictsId

        [MaxLength(32)]
        public string Name { get; set; } = null!;

        public virtual City City { get; set; } // Navigation Property
        public int CityId { get; set; }
    }
}
