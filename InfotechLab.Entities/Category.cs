﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Core;

namespace InfotechLab.Entities
{
	public class Category : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IList<UserCategory> UserCategories { get; set; }

	}
}
