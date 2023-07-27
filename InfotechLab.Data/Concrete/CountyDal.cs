using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Concrete;

namespace InfotechLab.Data.Concrete
{
    public class CountyDal : EfEntityRepositoryBase<County>, ICountyDal
    {
        public CountyDal(InfotechLabContext context) : base(context)
        {
        }
    }
}
