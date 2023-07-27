using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Data;
using InfotechLab.Entities;
using InfotechLab.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace InfotechLab.Business.Services.Concrete
{
	public class BidService : IBidService
	{
		private readonly IBidDal _repository;

		public BidService(IBidDal repository)
		{
			_repository = repository;
		}
		public Bid Add(Bid entity)
		{
			return _repository.Add(entity);
		}

		public bool Any(Expression<Func<Bid, bool>> filter)
		{
			return _repository.Any(filter);
		}

		public bool Delete(Bid entity)
		{
			return _repository.Delete(entity);
		}

		public Bid Get(Expression<Func<Bid, bool>> filter)
		{
			return _repository.Get(filter);
		}

		public IList<Bid> GetAll(Expression<Func<Bid, bool>> filter = null)
		{
			return _repository.GetAll(filter);
		}

		public InfotechLabContext GetContext()
		{
			throw new NotImplementedException();
		}

		public Bid Update(Bid entity)
		{
			return _repository.Update(entity);
		}
		public IList<Bid> GetAllBidsByUserCategory(Expression<Func<Bid, bool>> filter = null)
		{
			return _repository.GetAllBidsByUserCategory(filter);
		}

	}
}
