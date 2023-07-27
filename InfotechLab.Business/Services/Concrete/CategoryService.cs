using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Data;

namespace InfotechLab.Business.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryDal _repository;

		public CategoryService(ICategoryDal repository)
		{
			_repository = repository;
		}
		public Category Add(Category entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<Category, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(Category entity)
		{
			return _repository.Delete(entity);
		}

		public Category Get(Expression<Func<Category, bool>> filter)
		{
			return _repository.Get(filter);
		}

		public IList<Category> GetAll(Expression<Func<Category, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public Category Update(Category entity)
		{
			return _repository.Update(entity);
		}


	}
}
