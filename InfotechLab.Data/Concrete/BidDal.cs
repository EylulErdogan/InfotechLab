using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using InfotechLab.Data.Concrete;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace InfotechLab.Data.Concrete
{
    public class BidDal : EfEntityRepositoryBase<Bid>, IBidDal
    {
        public BidDal(InfotechLabContext context) : base(context)
        {
        }

		public IList<Bid> GetAllBidsByUserCategory(Expression<Func<Bid, bool>> filter = null)
		{
			var context = GetContext();
			var query = context.Bids.Include(x=>x.UserCategory).AsQueryable();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }
	}
}