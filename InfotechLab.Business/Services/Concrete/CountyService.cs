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
	public class CountyService : ICountyService
	{
		private readonly ICountyDal _repository;

		public CountyService(ICountyDal repository)
		{
			_repository = repository;
		}
		public County Add(County entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<County, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(County entity)
		{
			return _repository.Delete(entity);
		}

		public County Get(Expression<Func<County, bool>> filter)
		{
			return _repository.Get(filter);
		}

		public IList<County> GetAll(Expression<Func<County, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public County Update(County entity)
		{
			return _repository.Update(entity);
		}
	}
}
