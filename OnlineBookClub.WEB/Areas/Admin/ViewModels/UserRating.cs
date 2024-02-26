using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Areas.Admin.ViewModels
{
    public class UserRating
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }
        public byte Rate { get; set; }
    }
}
