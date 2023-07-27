using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Concrete;

namespace InfotechLab.Data.Concrete
{
	public class UserCategoryDal : EfEntityRepositoryBase<UserCategory>, IUserCategoryDal
	{
		public UserCategoryDal(InfotechLabContext context) : base(context)
		{
		}
		public bool DeleteAllUserCategoriesByUserId(int userId)
		{
			var entities = GetAll(x => x.UserId == userId);
			foreach (var entity in entities)
			{
				Delete(entity);
			}
			return true;
		}
	}
}
