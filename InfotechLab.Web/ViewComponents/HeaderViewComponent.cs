using InfotechLab.Business.ComponentHandler;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace InfotechLab.Web.ViewComponents
{
	public class HeaderViewComponent :ViewComponent
	{
		private readonly IUserService _userService;

		public HeaderViewComponent(IUserService userService)
		{
			_userService = userService;
		}

		public ViewViewComponentResult Invoke()
		{
			var result = _userService.GetUserData(Request);
			if (result != null)
			{
				if (string.IsNullOrEmpty(result.LoginGuidKey))
				{
                    return View();
                }

                ViewBag.Name = result?.FirstName + " " + result?.LastName;
				ViewBag.IsExpert = result?.IsExpert;
				ViewBag.UserId = result?.Id;
			}
			return View();
		}
	}
}

