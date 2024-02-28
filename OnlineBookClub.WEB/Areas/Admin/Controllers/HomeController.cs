using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineBookClub.WEB.Models.Identity;
using OnlineBookClub.WEB.Models;
using System.Runtime.CompilerServices;
using OnlineBookClub.WEB.Areas.Admin.ViewModels;

namespace OnlineBookClub.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly OnlineBookClubContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(OnlineBookClubContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            List<string> adminIds = _context.UserRoles
                .Where(x => x.RoleId == _context.Roles.FirstOrDefault(x => x.Name == "Admin").Id)
                .Select(x => x.UserId)
                .ToList();

            List<AppUser> admins = new List<AppUser>();

            foreach (var adminId in adminIds)
            {
                var admin = _context.Users.FirstOrDefault(u => u.Id == adminId);
                if (admin != null)
                {
                    admins.Add(admin);
                }
            }

            var model = new AdminStatisticsVM
            {
                TotalAdmins = admins.Count
            };

            Bagger();
            return View(model);
        }

        public void Bagger()
        {
            DateTime currentDate = DateTime.Now;
            var eventsBeforeCurrentDate = _context.Events.Where(e => e.StartDate < currentDate).Count();
            ViewBag.EventsBeforeCurrentDate = eventsBeforeCurrentDate;


            var activeEventsCount = _context.Events.Where(e => e.IS_ACTIVE == true).Count();
            ViewBag.ActiveEventsCount = activeEventsCount;


            ViewBag.UsersCount = _context.Users.Count();
            ViewBag.EventsCount = _context.Events.Count();
        }
    }
}
