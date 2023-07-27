using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Entities;

namespace InfotechLab.Business.Services.Abstract
{
	public interface IUserCategoryService : IEfEntityRepositoryBase<UserCategory>
	{
		bool DeleteAllUserCategoriesByUserId(int userId);
	}
}
