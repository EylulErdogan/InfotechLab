using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Business.Helpers;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Http;

namespace InfotechLab.Business.Services.Concrete
{
	public class UserService : IUserService
	{
		private readonly IUserDal _repository;
		private readonly ICookieHelper _cookieHelper;


		public UserService(IUserDal repository, ICookieHelper cookieHelper)
		{
			_repository = repository;
			_cookieHelper = cookieHelper;
		}
		public User Add(User entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<User, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(User entity)
		{
			return _repository.Delete(entity);
		}

		public User Get(Expression<Func<User, bool>> filter)
		{
			return _repository.Get(filter);
		}		
		public User GetIncluded(Expression<Func<User, bool>> filter)
		{
			return _repository.GetIncluded(filter);
		}

		public IList<User> GetAll(Expression<Func<User, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public User Update(User entity)
		{
			return _repository.Update(entity);
		}

		public User GetUserDataWithGuidKey(string guid)
		{
			return GetIncluded(x => x.LoginGuidKey == guid);
		}
		public void ResetUserGuidKey(string guid)
        {
	        var user = GetUserDataWithGuidKey(guid);
	        user.LoginGuidKey = null;
	        Update(user);
        }
		public User GetUserData(HttpRequest request)
		{
			// Bug: cookie silindi ise null
			var cookie = _cookieHelper.Read(CookieTypes.User, request);
			if (cookie is null)
			{
				return null;
			}
			var user = GetUserDataWithGuidKey(cookie);
			return user;
		}
		public IList<User> GetUsersInSelectedCategoryAndCounty(int categoryId, int countyId)
		{
			return _repository.GetUsersInSelectedCategoryAndCounty(categoryId, countyId);
		}
	}
}
