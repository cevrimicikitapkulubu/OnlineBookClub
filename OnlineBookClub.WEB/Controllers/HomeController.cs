using AspNetCoreIdentityApp.Extensions;
using AspNetCoreIdentityApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.Identity;
using System.Diagnostics;
using System.Security.Claims;
using OnlineBookClub.WEB.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;
using OnlineBookClub.WEB.Models.DB.Event;
using OnlineBookClub.WEB.ViewModels.Dist;

namespace OnlineBookClub.WEB.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly OnlineBookClubContext _context;
		private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, OnlineBookClubContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _context = context;
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			if (User.Identity!.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			List<SelectListItem> schoolListItems = new List<SelectListItem>();

            foreach (var school in _context.Schools.ToList())
            {
				schoolListItems.Add(new SelectListItem() { Text = school.Name, Value = school.Id.ToString() });
            }

			ViewBag.SchoolListItems = schoolListItems;

            return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpVM request)
		{

			if (!ModelState.IsValid)
			{
				return View();
			}

			var usernameIsExist = await _userManager.FindByNameAsync(request.UserName);
			if (usernameIsExist != null)
			{
				TempData["ExistUsernNme"] = $"'{request.UserName}'  daha önce başka bir kullanıcı tarafından alınmıştır.";
				return RedirectToAction(nameof(HomeController.SignUp));
			}

			var identityResult = await _userManager.CreateAsync(new() 
			{ 
				UserName = request.UserName, 
				Email = request.Email, 
				PhoneNumber = request.Phone,
				SchoolId = request.SchoolId,
				SchoolNo = request.SchoolNo
			}
			, request.PasswordConfirm);

			if (!identityResult.Succeeded)
			{
				ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
				return View();
			}

			//var exchangeExpireClaim = new Claim("ExchangeExpireDate", DateTime.Now.AddDays(10).ToString());
			//var user = await _userManager.FindByNameAsync(request.UserName);
			//var claimResult = await _userManager.AddClaimAsync(user, exchangeExpireClaim);

			//if (!claimResult.Succeeded)
			//{
			//	ModelState.AddModelErrorList(claimResult.Errors.Select(x => x.Description).ToList());
			//	return View();
			//}

			TempData["SuccessMessage"] = "Üyelik işlemi başarıyla gerçekleşmiştir.";
			return RedirectToAction(nameof(HomeController.SignUp));

		}

		public IActionResult LogIn()
		{
			if (User.Identity!.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			returnUrl = returnUrl ?? Url.Action("Index", "Home");

			var hasUser = await _userManager.FindByEmailAsync(request.Email);
			if (hasUser == null)
			{
				ModelState.AddModelError(string.Empty, "Email veya Şifre hatalı.");
				return View();
			}

			var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
			if (signInResult.Succeeded)
			{
				return Redirect(returnUrl!);
			}

			if (signInResult.IsLockedOut)
			{
				var userLockoutEndTime = await _userManager.GetLockoutEndDateAsync(hasUser);
				double userLockoutRemainTimeSec = (userLockoutEndTime.GetValueOrDefault().LocalDateTime - DateTime.Now).TotalSeconds;
				ModelState.AddModelErrorList(new List<string>() { $"Çok fazla yanlış deneme yaptınız, {TimeSpan.FromSeconds(userLockoutRemainTimeSec).ToString(@"m\:ss")} dakika sonra tekrar deneyiniz." });
				return View();
			}

			ModelState.AddModelErrorList(new List<string>() { $"Email veya Şifre hatalı." });


			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}











		//CLANDER AREA


        public async Task<IActionResult> Calendar()
		{
			List<Event> events = _context.Events.ToList();

			ViewBag.EventsJson = Json(events.Select(x => new CalendarVM { Title = x.Title, StartDate = (x.StartDate.Year + "-" + x.StartDate.Month.ToString("00") + "-" + x.StartDate.Day.ToString("00")), Time = x.StartDate.ToString("t") }));

			return View();

		}
	}
}
