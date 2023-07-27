using InfotechLab.Entities;
using InfotechLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace InfotechLab.Web.ViewComponents
{
	public class SearchExpertServiceViewComponent : ViewComponent
	{
		public SearchExpertServiceViewComponent()
		{
			
		}
		public ViewViewComponentResult Invoke()
		{
			return View(new SearchExpertServiceViewModel());
		}
	}
}
