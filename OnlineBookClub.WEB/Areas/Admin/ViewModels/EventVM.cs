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
        public DateTimeOffset CREATED_DATE { get; set; }
        public DateTime StartDate { get; set; }

        public List<Event> Events { get; set; }
    }
}
