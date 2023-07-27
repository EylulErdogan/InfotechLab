using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Abstract;
using InfotechLab.Data.Concrete;
using InfotechLab.Entities;

namespace InfotechLab.Data.Abstract
{
	public interface ICategoryDal : IEfEntityRepositoryBase<Category>
	{

	}
}
