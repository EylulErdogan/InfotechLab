using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Concrete;

namespace InfotechLab.Data.Concrete
{
	public class CategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
	{
        public CategoryDal(InfotechLabContext context) : base(context)
        {
        }
	}
}

