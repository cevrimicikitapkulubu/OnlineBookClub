using AspNetCoreIdentityApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using OnlineBookClub.WEB.Enums;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.Identity;
using OnlineBookClub.WEB.ViewModels.Auth;
using System.Security.Claims;

namespace OnlineBookClub.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly OnlineBookClubContext _context;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IFileProvider fileProvider, OnlineBookClubContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _fileProvider = fileProvider;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            UserVM userVM = new UserVM
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
                Department = _context.Departments.FirstOrDefault(x => x.Id == currentUser.DepartmentId),
                Firstname = currentUser.Firstname,
                Lastname = currentUser.Lastname,
                Gender = currentUser.Gender,
                Level = _context.Levels.FirstOrDefault(x => x.LevelId == currentUser.LevelId),
                Point = currentUser.Point,
                School = _context.Schools.FirstOrDefault(x => x.Id == currentUser.SchoolId),
                SchoolNo = currentUser.SchoolNo,
                ProfilePicture = string.IsNullOrEmpty(currentUser.ProfilePicture) ? "DefaultUserPicture.jpg" : currentUser.ProfilePicture
            };
            return View(userVM);
        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            var checkOldPassword = _userManager.CheckPasswordAsync(currentUser, request.PasswordOld).Result;

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlış!");
                return View();
            }

            var result = await _userManager.ChangePasswordAsync(currentUser, request.PasswordOld, request.PasswordNew);

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser, request.PasswordNew, true, false);

            TempData["SuccessMessage"] = "Şifre başarıyla değişti.";

            return View();
        }

        public async Task<IActionResult> UserEdit()
        {
            ViewBag.genderList = new SelectList(Enum.GetNames(typeof(Gender)));
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            UserEditVM model = new UserEditVM()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber,
                Firstname = currentUser.Firstname!,
                Lastname = currentUser.Lastname!,
                SchoolNo = currentUser.SchoolNo!
            };

			UserVM userVM = new UserVM
			{
				UserName = currentUser.UserName,
				Email = currentUser.Email,
				PhoneNumber = currentUser.PhoneNumber,
				Department = _context.Departments.FirstOrDefault(x => x.Id == currentUser.DepartmentId),
				Firstname = currentUser.Firstname,
				Lastname = currentUser.Lastname,
				Gender = currentUser.Gender,
				Level = _context.Levels.FirstOrDefault(x => x.LevelId == currentUser.LevelId),
				Point = currentUser.Point,
				School = _context.Schools.FirstOrDefault(x => x.Id == currentUser.SchoolId),
				SchoolNo = currentUser.SchoolNo,
				ProfilePicture = string.IsNullOrEmpty(currentUser.ProfilePicture) ? "DefaultUserPicture.jpg" : currentUser.ProfilePicture
			};

            ViewBag.UserVM = userVM;

			return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            currentUser.UserName = request.UserName;
            currentUser.Email = request.Email;
            currentUser.PhoneNumber = request.Phone;
            currentUser.Firstname = request.Firstname;
            currentUser.Lastname = request.Lastname;    
            currentUser.SchoolNo = request.SchoolNo;

            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                string randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.ProfilePicture.FileName)}";

                string userpicturesPath = wwwrootFolder.First(x => x.Name == "img").PhysicalPath + "\\userpictures";

                var newPicturePath = Path.Combine(userpicturesPath, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await request.ProfilePicture.CopyToAsync(stream);

                currentUser.ProfilePicture = randomFileName;
            }

            var result = await _userManager.UpdateAsync(currentUser);

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);

            TempData["SuccessMessage"] = "Your info are successfully changed.";

            UserEditVM model = new UserEditVM()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber,
                Firstname = currentUser.Firstname!,
                Lastname = currentUser.Lastname!,
                SchoolNo = currentUser.SchoolNo!
            };

            return View(model);
        }

        public async Task<IActionResult> LogOut(string returnurl)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Claims()
        {
            var userClaimList = User.Claims.Select(x => new ClaimVM()
            {
                Issuer = x.Issuer,
                Type = x.Type,
                Value = x.Value
            }).ToList();

            return View(userClaimList);
        }

        [Authorize(Policy = "SchoolPage")]
        public IActionResult SchoolPage()
        {
            return View();
        }

        public async Task<IActionResult> AccessDenied(string ReturnUrl)
        {
            string message = string.Empty;

            message = "You are not have permission for enter this page!";
            ViewBag.message = message;
            return View();
        }
    }
}
