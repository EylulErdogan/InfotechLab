using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class Bid : IEntity
	{
		public int Id { get; set; }
		public int UserId { get; set; }	
		public int UserCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
		public DateTime? FinishDate { get; set; }
		public decimal? Price { get; set; }
		public bool? IsAccepted { get; set; }
		public string? Description { get; set; }
		public User User { get; set; }
		public UserCategory UserCategory { get; set; }

	}
}
