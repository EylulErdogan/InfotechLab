using InfotechLab.Business.Helpers;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using InfotechLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfotechLab.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserService _userService;
		private readonly ICategoryService _categoryService;
		private readonly ICityService _cityService;
		private readonly ICountyService _countyService;
		private ICookieHelper _cookieHelper;


		public HomeController(ILogger<HomeController> logger, IUserService userService, ICookieHelper cookieHelper, ICategoryService categoryService, ICityService cityService, ICountyService countyService)
		{
			_logger = logger;
			_userService = userService;
			_cookieHelper = cookieHelper;
			_categoryService = categoryService;
            _cityService = cityService;
            _countyService = countyService;
        }
		public IActionResult Index()
        {
			var user = _userService.GetUserData(Request);
			if (user is not null)
            {
				ViewBag.Name = user.FirstName + " " + user.LastName;
				ViewBag.UserId = user.Id;
            }
            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}