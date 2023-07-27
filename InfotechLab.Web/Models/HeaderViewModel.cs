using InfotechLab.Entities;
using System.Diagnostics.Metrics;

namespace InfotechLab.Web.Models
{
	public class HeaderViewModel
    {
        public IList<City> Cities { get; set; }
        public IList<County> Counties { get; set; }
        public IList<Category> Categories { get; set; }
        public SearchExpertServiceViewModel SearchExpertService { get; set; }
    }
}
