using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfotechLab.Business.Models
{
    public class Result<TResultType>
    {
        public IList<string> ErorMessages { get; set; }
        public bool IsList { get; set; }
        public bool IsOk { get; set; }
        public IList<TResultType> List { get; set; }
        public TResultType SingleObject { get; set; }
    }
}
