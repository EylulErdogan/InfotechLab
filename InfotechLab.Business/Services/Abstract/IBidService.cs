using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Data;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;
using System.Linq.Expressions;

namespace InfotechLab.Business.Services.Abstract
{
	public interface IBidService : IEfEntityRepositoryBase<Bid>
	{
		public IList<Bid> GetAllBidsByUserCategory(Expression<Func<Bid, bool>> filter = null);
	}
}
