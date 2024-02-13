using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentityApp.Requirements
{
    public class ExchangeExpireRequirement:IAuthorizationRequirement
    {

    }

    public class ExchangeExpirationRequirementHandler : AuthorizationHandler<ExchangeExpireRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExchangeExpireRequirement requirement)
        {

            if (context.User.HasClaim(x => x.Type == "ExchangeExpireDate") == false)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var exchangeExpireDate = context.User.Claims.First(x => x.Type == "ExchangeExpireDate");

            if (DateTime.Now < Convert.ToDateTime(exchangeExpireDate.Value)) {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);


            return Task.CompletedTask;
        }
    }
}
