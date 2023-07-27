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
	public class CityService : ICityService
	{
		private readonly ICityDal _repository;

		public CityService(ICityDal repository)
		{
			_repository = repository;
		}
		public City Add(City entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<City, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(City entity)
		{
			return _repository.Delete(entity);
		}

		public City Get(Expression<Func<City, bool>> filter)
		{
			return _repository.Get(filter);
		}

		public IList<City> GetAll(Expression<Func<City, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public City Update(City entity)
		{
			return _repository.Update(entity);
		}
	}
}
