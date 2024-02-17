using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Models.DB.Const
{
    public class School
    {
        public short Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; } = null!;

        public Int16 DistrictId { get; set; }

        //?=========> REFERANCES

        public virtual District District { get; set; }
    }
}
