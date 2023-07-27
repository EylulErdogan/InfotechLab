
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace InfotechLab.Web.ViewComponents
{
	public class CategoryAreaViewComponent :ViewComponent
	{
		private readonly ICategoryService _categoryService;
		public CategoryAreaViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public ViewViewComponentResult Invoke()
		{
			return View(_categoryService.GetAll());
		}
	}
}
