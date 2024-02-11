using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.ViewModels;

namespace OnlineBookClub.WEB.Controllers
{
    public class EventController : Controller
    {
        private OnlineBookClubContext context;

        public EventController(OnlineBookClubContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            Event_IndexVM vm = new Event_IndexVM()
            {
                Events = context.Events.Include(x => x.EventSubjects).Include(x => x.Location).ToList(),
            };

            return View(vm);
        }
    }
}
