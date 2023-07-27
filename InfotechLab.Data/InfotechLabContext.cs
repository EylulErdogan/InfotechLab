using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InfotechLab.Data
{
	public class InfotechLabContext :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Database bağlantı cümlesi 
			//Connection String gelecek 
			optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored, CoreEventId.NavigationBaseIncluded));
			optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=InfotechLab;Integrated Security=True");
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<County> Counties { get; set; }
		public DbSet<UserCategory> UserCategories { get; set; }

	}
}
