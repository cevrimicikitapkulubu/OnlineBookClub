using OnlineBookClub.WEB.Models.DB.Event;

namespace OnlineBookClub.WEB.Areas.Admin.ViewModels
{
    public class RatingVM
    {
        public int EventId { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }

    }
}
