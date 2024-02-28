using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookClub.WEB.Areas.Admin.ViewModels;
using OnlineBookClub.WEB.Controllers;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.Models.Identity;
using OnlineBookClub.WEB.ViewModels.Auth;

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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            _context.Events.AddAsync(new Models.DB.Event.Event()
            {
                CREATED_DATE = DateTimeOffset.UtcNow,
                Title = request.Title,
                ISBN = request.ISBN,
                LocationId = request.LocationId,
                StartDate = request.StartDate,
                CREATED_USER_ID = user.Id,
                SchoolId = user.SchoolId
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Admin.Controllers.EventController.Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Areas.Admin.ViewModels.EventDetail eventDetail = new Areas.Admin.ViewModels.EventDetail() 
            {
                Event = _context.Events
                .Include(x => x.School)
                .Include(x => x.EventParticipants)
                .Include(x => x.EventRatings)
                .Include(x => x.EventSubjects)
                .Include(x => x.Location)
                .FirstOrDefault(x => x.Id == id)!,

                EventRatings = _context.EventRatings.Where(x => x.EventId == id).ToList(),
                EventRequirements = _context.EventRequirements.Where(x => x.EventId == id).ToList(),
                EventSubjects = _context.EventSubjects.Where(x => x.EventId == id).ToList(),
            };

            List<UserRating> users = new List<UserRating>();
            foreach (var user in _context.Users.ToList())
            {
                foreach (var eventParticipant in _context.EventParticipants.Include(x => x.Rating))
                {
                    if (eventParticipant.UserId == user.Id)
                    {
                        UserRating rating = new UserRating()
                        {
                            UserId = user.Id,
                            Description = eventParticipant.Description,
                            Rate = eventParticipant.Rating.Rate,
                            User = user
                        };

                        users.Add(rating);
                    }
                }
            }

            eventDetail.UserRatings = users;

            return View(eventDetail);
        }













        // |Delete Method|
        public async Task<IActionResult> Delete(int id)
        {
            var events = _context.Events.FirstOrDefault(x => x.Id == id);
            _context.Events.Remove(events);
            _context.SaveChanges();

            return RedirectToAction(nameof(Admin.Controllers.EventController.Index));
        }


        // |Update Method|
        //[HttpPost]
        //public async Task<IActionResult> Update(EventVM eventvm)
        //{
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);

        //    Event events = new Event()
        //    {
        //        Id = eventvm.Id,
        //        CREATED_DATE = eventvm.CREATED_DATE,
        //        Title = eventvm.Title,
        //        ISBN = eventvm.ISBN,
        //        LocationId = eventvm.LocationId,
        //        StartDate = eventvm.StartDate,
        //        CREATED_USER_ID = user.Id,
        //        SchoolId = user.SchoolId
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        _context.Events.Update(events);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", _context.Events.ToList());
        //    }

        //    _context.SaveChanges();

        //    return View(eventvm);
        //}



        //public JsonResult GetEvents()
        //{
        //    var events = _context.Events.ToList();
        //    return Json(events);
        //}


        //[HttpGet]
        //public JsonResult Edit(int id)
        //{
        //    var events = _context.Events.FirstOrDefault(x => x.Id == id);
        //    return Json(events);
        //}

        //[HttpPost]
        //public JsonResult Update(Event model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Events.Update(model);
        //        _context.SaveChanges();
        //        return Json("Event details updated.");
        //    }

        //    return Json("Model State Validation Failed.");
        //}
    }
}
