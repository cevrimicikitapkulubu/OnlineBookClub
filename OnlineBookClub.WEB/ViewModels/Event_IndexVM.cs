using OnlineBookClub.WEB.Models.DB.Event;

namespace OnlineBookClub.WEB.ViewModels
{
    public class Event_IndexVM
    {
        public List<Event> Events { get; set;}
        public List<EventSubject> EventSubjects { get; set;}
    }
}
