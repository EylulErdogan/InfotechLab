using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace InfotechLab.Web.ViewComponents
{
	public class SliderAreaViewComponent : ViewComponent
	{
		public SliderAreaViewComponent()
		{
			
		}
		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
