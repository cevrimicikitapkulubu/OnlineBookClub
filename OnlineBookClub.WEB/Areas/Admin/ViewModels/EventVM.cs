using Microsoft.CodeAnalysis;
using OnlineBookClub.WEB.Models.DB.Event;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookClub.WEB.Areas.Admin.ViewModels
{
    public class EventVM
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public string Question_1 { get; set; }
        public string Question_2 { get; set; }
        public string Question_3 { get; set; }

        public List<Event> Events { get; set; }
    }
}
