using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBookClub.WEB.Areas.Admin.ViewModels;
using OnlineBookClub.WEB.Controllers;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.Identity;

namespace OnlineBookClub.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly OnlineBookClubContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EventController(OnlineBookClubContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            EventVM model = new EventVM();
            model.Events =  _context.Events.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventVM request)
        {
            _context.Events.AddAsync(new Models.DB.Event.Event()
            {
                CREATED_DATE = DateTimeOffset.UtcNow,
                Title = request.Title,
                ISBN = request.ISBN,
                LocationId = request.LocationId,
                StartDate = request.StartDate,
                //CREATED_USER_ID = _userManager.FindByNameAsync(User.Identity.Name).Id,
                CREATED_USER_ID = "d5af1b61-782a-432d-977f-48d4b5018f16",
                SchoolId = 1
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Admin.Controllers.EventController.Index));
        }
    }
}
