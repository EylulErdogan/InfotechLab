using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class City :IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
