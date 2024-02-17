using AspNetCoreIdentityApp.ClaimProviders;
using AspNetCoreIdentityApp.Extentisons;
using AspNetCoreIdentityApp.OptionsModels;
using AspNetCoreIdentityApp.Requirements;
using AspNetCoreIdentityApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OnlineBookClub.WEB.Data;
using OnlineBookClub.WEB.Models;
using OnlineBookClub.WEB.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineBookClubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));

//Default = 30 Minute
builder.Services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromMinutes(15));

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddIdentityWithExt();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();
builder.Services.AddScoped<IAuthorizationHandler, ExchangeExpirationRequirementHandler>();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("SchoolPage", policy =>
	{
		policy.RequireClaim("SchoolNo", "9648");
	});

	//options.AddPolicy("ExchangePolicy", policy =>
	//{
	//	policy.AddRequirements(new ExchangeExpireRequirement());
	//});
});

builder.Services.ConfigureApplicationCookie(option =>
{
	var cookieBuilder = new CookieBuilder();
	cookieBuilder.Name = "AspNetCoreIdentityApp";
	option.LoginPath = new PathString("/Home/SignIn");
	option.LogoutPath = new PathString("/Member/Logout");
	option.AccessDeniedPath = new PathString("/Home/Error");
	option.Cookie = cookieBuilder;
	option.ExpireTimeSpan = TimeSpan.FromDays(60);
	option.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	DataSeeding.Seed(app);
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "SignUp",
            pattern: "SignUp",
            defaults: new { controller = "Home", action = "SignUp" });

    endpoints.MapControllerRoute(
           name: "LogIn",
           pattern: "LogIn",
           defaults: new { controller = "Home", action = "Login" });

    endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
