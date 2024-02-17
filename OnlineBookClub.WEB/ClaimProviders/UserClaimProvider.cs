using OnlineBookClub.WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using OnlineBookClub.WEB.Models.Identity;

namespace AspNetCoreIdentityApp.ClaimProviders
{
    public class UserClaimProvider : IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public UserClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identityPrinipal = principal.Identity as ClaimsIdentity;
            var currentUser = await _userManager.FindByNameAsync(identityPrinipal!.Name);

   //         if (currentUser.School != null)
   //         {
   //             if (principal.HasClaim(x => x.Type != "School"))
   //             {
   //                 Claim schoolIdClaim = new Claim("School", currentUser.School.Id.ToString());
   //                 identityPrinipal.AddClaim(schoolIdClaim);
   //             }
   //         }

			//if (!string.IsNullOrEmpty(currentUser.SchoolNo))
			//{
			//	if (principal.HasClaim(x => x.Type != "School"))
			//	{
			//		Claim schoolNoClaim = new Claim("School", currentUser.SchoolNo);
			//		identityPrinipal.AddClaim(schoolNoClaim);
			//	}
			//}

            if (!string.IsNullOrEmpty(currentUser.ProfilePicture))
            {
                if (principal.HasClaim(x => x.Type != "ProfilePicture"))
                {
                    Claim profilePictureClaim = new Claim("ProfilePicture", currentUser.ProfilePicture);
                    identityPrinipal.AddClaim(profilePictureClaim);
                }
            }

			return principal;
        }
    }
}
