using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class User : IEntity
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? BirthOfDate { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? LoginGuidKey { get; set; }
		public string Description { get; set; }

		public int CountyId { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
        public bool IsExpert { get; set; }
        public County County { get; set; }
        public IList<UserCategory> UserCategories { get; set; }


    }
}
