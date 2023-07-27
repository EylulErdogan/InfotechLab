using InfotechLab.Entities;
using System.ComponentModel.DataAnnotations;

namespace InfotechLab.Web.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
			Categories = new List<Category>();
		}
        [Required(ErrorMessage = "İsim boş Bırakılamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim boş Bırakılamaz")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Adresi boş Bırakılamaz")]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Hatalı Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Giriniz"), MaxLength(12, ErrorMessage = "12 Karakterden uzun olamaz")]
        public string Password { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsExpert { get; set; }
        public DateTime BirthOfDate { get; set; }
		public int[] CategoryIds { get; set; }
		public int CityId { get; set; }
		public int CountyId { get; set; }
		public IList<Category> Categories { get; set; }

	}
}
