using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class County : IEntity
	{
		public int Id { get; set; }
		public int CityId { get; set; }
		public string Name { get; set; }
        public City City { get; set; }
		public IList<UserCategory> UserCategories { get; set; }

	}
}
