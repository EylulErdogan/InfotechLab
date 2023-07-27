using InfotechLab.Business.ComponentHandler;
using InfotechLab.Business.Helpers;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Business.Services.Concrete;
using InfotechLab.Data;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Web.ViewComponents;

namespace InfotechLab.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();


			builder.Services.AddScoped<InfotechLabContext>();
			builder.Services.AddScoped<IBidDal, BidDal>();
			builder.Services.AddScoped<ICategoryDal, CategoryDal>();
			builder.Services.AddScoped<ICityDal, CityDal>();
			builder.Services.AddScoped<ICountyDal, CountyDal>();
			builder.Services.AddScoped<IUserCategoryDal, UserCategoryDal>();
			builder.Services.AddScoped<IUserDal, UserDal>();


			builder.Services.AddScoped<IBidService, BidService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICityService, CityService>();
			builder.Services.AddScoped<ICountyService, CountyService>();
			builder.Services.AddScoped<IUserCategoryService, UserCategoryService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ILoginService, LoginService>();



			builder.Services.AddScoped<ICookieHelper, CookieHelper>();
			builder.Services.AddScoped<IHeaderComponentHandler, HeaderComponentHandler>();




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthorization();


			//app.MapControllerRoute(
			//   name: "Login",
			//   pattern: "/login/",
			//   defaults: new { controller = "Authentication", action = "Login" });

			//app.MapControllerRoute(
			//	name: "Register",
			//	pattern: "/register/",
			//	defaults: new { controller = "Authentication", action = "Register" });

			//app.MapControllerRoute(
			//	name: "Profile",
			//	pattern: "/profile/",
			//	defaults: new { controller = "UserProfile", action = "Index" });

			//app.MapControllerRoute(
			//	name: "Error",
			//	pattern: "/error/",
			//	defaults: new { controller = "Authentication", action = "Exit" });

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}");

			app.Run();
		}
	}
}