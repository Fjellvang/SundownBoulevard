using Microsoft.EntityFrameworkCore;
using SundownBoulevard.Core.Booking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Data
{
	public class SundownBoulevardDbContext : DbContext
	{
		public SundownBoulevardDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Booker> Bookers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Day> Days { get; set; }
	}
}
