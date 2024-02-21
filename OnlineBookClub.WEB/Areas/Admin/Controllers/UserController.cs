using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBookClub.WEB.Models.Identity;
using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using OnlineBookClub.WEB.Areas.Admin.ViewModels;

namespace OnlineBookClub.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly OnlineBookClubContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(OnlineBookClubContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }



        public IActionResult Index()
        {
            UserVM model = new UserVM();
            model.Users = _userManager.Users.ToList();


            return View(model);
        }
    }
}
