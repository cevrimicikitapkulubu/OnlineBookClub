using OnlineBookClub.WEB.Models.DB.Const;
using OnlineBookClub.WEB.Models.DB.Event;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Areas.Admin.ViewModels
{
    public class EventDetail
    {
        public Event Event { get; set; }
        public List<EventRating> EventRatings { get; set; }
        public List<EventSubject> EventSubjects { get; set; }
        public List<EventRequirement> EventRequirements { get; set; }
        public List<UserRating> UserRatings { get; set; }
    }
}
