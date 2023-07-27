using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using InfotechLab.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfotechLab.Web.Controllers
{
	public class UserProfileController : Controller
	{
		private ICategoryService _categoryService;
		private IUserService _userService;
		private IUserCategoryService _userCategoryService;
		private IBidService _bidService;


		public UserProfileController(ICategoryService categoryService, IUserService userService, IUserCategoryService userCategoryService, IBidService bidService)
		{
			_categoryService = categoryService;
			_userService = userService;
			_userCategoryService = userCategoryService;
			_bidService = bidService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Index(int userId)
		{
			var userProfile = _userService.GetIncluded(x => x.Id == userId);
			var userModel = new UserModel
			{
				FirstName = userProfile.FirstName,
				LastName = userProfile.LastName,
				Email = userProfile.Email,
				BirthOfDate = userProfile.BirthOfDate,
				Address = userProfile.Address,
				Description = userProfile.Description,
				PhoneNumber = userProfile.PhoneNumber,
				Categories = _categoryService.GetAll(),
				CategoryIds = userProfile.UserCategories.Select(c => c.Id).ToArray(),
				CreatedDate = userProfile.CreatedDate,
				Id = userProfile.Id,
				IsActive = userProfile.IsActive,
				IsExpert = userProfile.IsExpert,
				LoginGuidKey = userProfile.LoginGuidKey,
				CountyId = userProfile.CountyId,
				CityId = userProfile.County.CityId,
			};
			return View(userModel);
		}
		[HttpPost]
		public IActionResult Index(UserModel userProfile)
		{
			if (userProfile.CityId == 0 || userProfile.CountyId == 0 || userProfile.IsExpert && (userProfile.CategoryIds is null || userProfile.CategoryIds.Length == 0))
			{
				ViewBag.Error = " Lütfen bilgileri kontrol ediniz!";
				return RedirectToAction("Index", "UserProfile", new { userId = userProfile.Id });
			}
			var countyId = _userService.Get(x => x.Id == userProfile.Id);
			var user = _userService.Get(x => x.Id == userProfile.Id);
			user.FirstName = userProfile.FirstName;
			user.LastName = userProfile.LastName;
			user.Email = userProfile.Email;
			user.BirthOfDate = userProfile.BirthOfDate;
			user.Address = userProfile.Address;
			user.Description = userProfile.Description;
			user.PhoneNumber = userProfile.PhoneNumber;
			user.IsExpert = userProfile.IsExpert;
			user.CountyId = userProfile.CountyId;
			user.UserCategories = null;
			user.County = null;

			_userService.Update(user);
			if (userProfile.IsExpert)
			{
				foreach (var categoryId in userProfile.CategoryIds)
				{
					_userCategoryService.DeleteAllUserCategoriesByUserId(userProfile.Id);
				}
				foreach (var categoryId in userProfile.CategoryIds)
				{
					_userCategoryService.Add(new UserCategory { CategoryId = categoryId, UserId = user.Id, CountyId = user.CountyId });
				}
			}
			return RedirectToAction("Index", "UserProfile",new {userId = user.Id});
		}


		public IActionResult UserBids()
		{
			var user = _userService.GetUserData(Request);
			var bids = _bidService.GetAll(x => x.UserId == user.Id);
			return View(bids);
		}	
		
		public IActionResult ExpertBids()
		{
			var user = _userService.GetUserData(Request);
			var bids = _bidService.GetAllBidsByUserCategory(x => x.UserCategory.UserId == user.Id);
			return View(bids);
		}
	}
}
