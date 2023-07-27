using InfotechLab.Business.Services.Abstract;
using InfotechLab.Business.Services.Concrete;
using InfotechLab.Entities;
using InfotechLab.Web.Models;
using InfotechLab.Web.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace InfotechLab.Web.Controllers
{
	public class CategoryListController : Controller
	{
		private readonly IUserService _userService;
		ICategoryService _categoryService;
		ICityService _cityService;
		ICountyService _countyService;
		IUserCategoryService _userCategoryService;
		private IBidService _bidService;

		public CategoryListController(ICategoryService categoryService, ICityService cityService, ICountyService countyService, IUserService userService, IUserCategoryService userCategoryService, IBidService bidService)
		{
			_categoryService = categoryService;
			_cityService = cityService;
			_countyService = countyService;
			_userService = userService;
			_userCategoryService = userCategoryService;
			_bidService = bidService;
		}
		public IActionResult Index(int Id)
		{
			var user = _userService.GetUserData(Request);
			if (user is null)
			{
				return RedirectToAction("Login", "Authentication");
			}
			var result = _userService.GetUsersInSelectedCategoryAndCounty(Id, user.CountyId);
			ViewData["CategoryId"] = Id;
			return View(result);
		}
		public IActionResult GetUserCityCountyAndCategoryId()
		{
			var user = _userService.GetUserData(Request);
			var cityId = _countyService.Get(x => x.Id == user.CountyId).CityId;
			var categoryIds = _userCategoryService.GetAll(x => x.UserId == user.Id).Select(x => x.CategoryId).ToArray();

			return Json(new { userId = user.Id, countyId = user.CountyId, cityId = cityId, categoryIds = categoryIds });
		}
		public IActionResult GetCities()
		{
			return Json(_cityService.GetAll());
		}
		public IActionResult GetCounties(int cityId)
		{
			return Json(_countyService.GetAll(x => x.CityId == cityId));
		}
		public IActionResult GetCategories()
		{
			return Json(_categoryService.GetAll());
		}
		
		[HttpPost]
		public IActionResult SearchExpertService(SearchExpertServiceViewModel model)
		{
			var user = _userService.GetUserData(Request);
			if (user is null)
			{
				return RedirectToAction("Login", "Authentication");
			}
			else
			{
				var result = _userService.GetUsersInSelectedCategoryAndCounty(model.CategoryId, model.CountyId);
				ViewData["CategoryId"] = model.CategoryId;
				return View("Index", result);
			}
		}

		public IActionResult CreateBid(int expertId, int categoryId)
		{
			var user = _userService.GetUserData(Request);
			var userCategory = _userCategoryService.Get(x => x.UserId == expertId && x.CategoryId == categoryId);
			Bid model = new Bid
			{
				UserCategoryId = userCategory.Id,
				UserId = user.Id
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult CreateBid(Bid model)
		{
			var user = _userService.GetUserData(Request);
			_bidService.Add(new Bid
			{
				CreatedDate = DateTime.Now,
				UserCategoryId = model.UserCategoryId,
				UserId = user.Id,
				IsAccepted = false,
				Description = model.Description,
			});
			return RedirectToAction("UserBids", "UserProfile");
		}
		public IActionResult ExpertCreateBid(int bidId)
		{
			var expert = _userService.GetUserData(Request);
			var bid = _bidService.Get(x => x.Id == bidId);
			return View(bid);
		}
		[HttpPost]
		public IActionResult ExpertCreateBid(Bid model)
		{
			var user = _userService.GetUserData(Request);
			var bid = _bidService.Get(x => x.Id == model.Id);
			bid.Price = model.Price;
			bid.FinishDate = model.FinishDate;
			_bidService.Update(bid);
			return RedirectToAction("ExpertBids", "UserProfile");
		}
		public IActionResult AcceptBid(int id)
		{
			var bid = _bidService.Get(x => x.Id == id);
			bid.IsAccepted = true;
			_bidService.Update(bid);
			return RedirectToAction("UserBids", "UserProfile");
		}
	}
}
