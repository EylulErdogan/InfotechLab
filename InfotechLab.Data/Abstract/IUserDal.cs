using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Concrete;

namespace InfotechLab.Data.Abstract
{
	public interface IUserDal : IEfEntityRepositoryBase<User>
	{
		User GetIncluded(Expression<Func<User, bool>> filter);
		IList<User> GetUsersInSelectedCategoryAndCounty(int categoryId, int countyId);

		string ChangeGuidKey(User user);
        User Register(User user);
	}
}
