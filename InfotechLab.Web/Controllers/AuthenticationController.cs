using InfotechLab.Business.Helpers;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using InfotechLab.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfotechLab.Web.Controllers
{
	public class AuthenticationController : Controller
	{
		private ILoginService _loginService;
		private ICategoryService _categoryService;
		private ICookieHelper _cookieHelper;
		public AuthenticationController(ILoginService loginService, ICookieHelper cookieHelper, ICategoryService categoryService)
		{
			_loginService = loginService;
			_cookieHelper = cookieHelper;
			_categoryService = categoryService;
		}

		public IActionResult Login()
		{
			var cookie = _cookieHelper.Read(CookieTypes.User, Request);
			if (!string.IsNullOrEmpty(cookie))
			{

			}
			return View();
		}
		public IActionResult Register()
		{
			RegisterViewModel viewModel = new RegisterViewModel();
			viewModel.Categories = _categoryService.GetAll();
			return View(viewModel);
		}
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
					var loginResult = _loginService.UserLogin(model.Email, model.Password, Response);
					return RedirectToAction("Index", "Home");
			}

			else
			{
				return View(model);
			}
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		
		{
			if (ModelState.IsValid)
			{
				var modelUser = new User()
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					Password = model.Password,
					IsActive = true,
					CreatedDate = DateTime.Now,
					BirthOfDate = model.BirthOfDate,
					IsExpert = model.IsExpert,
					Description = model.Description,
					Address = model.Address,

					CountyId = model.CountyId,

					
					
				};
				var user = _loginService.Register(modelUser, Response);
				if (user != null)
				{
					//hizmet alan sayfasına gitsin
					return RedirectToAction("Index", "Home");
				}
			}

			return View(model);
		}

		public IActionResult Exit()
		{
			bool result = _loginService.Exit(Request);
			if (result)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Error", "Home");
			}
			return View();
		}		
		public IActionResult LoginRequired()
		{
			return View();
		}
	}
}
