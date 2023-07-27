using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace InfotechLab.Data.Concrete
{
	public class UserDal : EfEntityRepositoryBase<User>, IUserDal
	{
        public UserDal(InfotechLabContext context) : base(context)
        {
        }

        public string ChangeGuidKey(User user)
        {
            var key = Guid.NewGuid().ToString();
            user.LoginGuidKey = key;
            Update(user);
            return key;
        }

        public User Register(User user)
        {
            var exist = Any(x => x.Email == user.Email);
            if (exist)
            {
                return null;
            }
            var output = Add(user);
            if (output == null)
            {
                return null;
            }
            else
            {
                return output;
            }
         
		}
		public User GetIncluded(Expression<Func<User, bool>> filter)
		{
			var context = GetContext();
            var query = context.Users.Include(x => x.UserCategories).ThenInclude(y => y.User).Include(x => x.UserCategories).ThenInclude(y => y.County).Include(x => x.UserCategories).ThenInclude(y => y.Category).Include(x => x.County).ThenInclude(y => y.City).AsQueryable();

            if (filter is not null)
            {
				query = query.Where(filter);
			}

			return query.FirstOrDefault();
		}		
        public IList<User> GetUsersInSelectedCategoryAndCounty(int categoryId, int countyId)
        {
			var context = GetContext();
            return context.Users.Include(x => x.UserCategories).ThenInclude(y => y.User).Where(x => x.UserCategories.Any(y => y.CategoryId == categoryId && y.CountyId == countyId && y.User.IsExpert)).ToList();
		}


	}
}

