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
    public class CityDal : EfEntityRepositoryBase<City>, ICityDal
    {
        public CityDal(InfotechLabContext context) : base(context)
        {
        }
    }
}
