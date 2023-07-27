using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Entities;

namespace InfotechLab.Business.Services.Concrete
{
	public class UserCategoryService : IUserCategoryService
	{
		private readonly IUserCategoryDal _repository;

		public UserCategoryService(IUserCategoryDal repository)
		{
			_repository = repository;
		}
		public UserCategory Add(UserCategory entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<UserCategory, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(UserCategory entity)
		{
			return _repository.Delete(entity);
		}

		public UserCategory Get(Expression<Func<UserCategory, bool>> filter)
		{
			return _repository.Get(filter);
		}

		public IList<UserCategory> GetAll(Expression<Func<UserCategory, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public UserCategory Update(UserCategory entity)
		{
			return _repository.Update(entity);
		}
		public bool DeleteAllUserCategoriesByUserId(int userId)
		{
			return _repository.DeleteAllUserCategoriesByUserId(userId);
		}
	}
}
