using InfotechLab.Entities;

namespace InfotechLab.Web.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? BirthOfDate { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public string LoginGuidKey { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsExpert { get; set; }
		public IList<Bid> Bids { get; set; }
		public int[] CategoryIds { get; set; }
		public int CityId { get; set; }
		public int CountyId { get; set; }
		public IList<Category> Categories { get; set; }
	}
}
