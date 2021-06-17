using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Data.Entities
{
	public class Booker
	{
		public int Id { get; set; }
		public string Email { get; set; }

		public IEnumerable<Order> Orders { get; set; }
	}
}
