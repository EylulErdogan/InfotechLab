using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class UserCategory : IEntity
	{
		public int Id { get; set; }
		public int CountyId { get; set; }
		public int CategoryId { get; set; }
		public int UserId { get; set; }
		public County County { get; set; }
		public Category Category { get; set; }
		public User User { get; set; }

	}
}
