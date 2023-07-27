using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Http;

namespace InfotechLab.Business.Services.Abstract
{
	public interface IUserService : IEfEntityRepositoryBase<User>
	{
		IList<User> GetUsersInSelectedCategoryAndCounty(int categoryId, int countyId);
		public User GetUserData(HttpRequest request);
		void ResetUserGuidKey(string guid);
        User GetUserDataWithGuidKey(string guid);
		User GetIncluded(Expression<Func<User, bool>> filter);



	}
}
