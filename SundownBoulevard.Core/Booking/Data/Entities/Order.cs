using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Data.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public long BookingStartTicks { get; set; }
		public long BookingEndTicks { get; set; }
		public int NumberOfTables { get; set; }
		public int BookerId { get; set; }
		public Booker Booker { get; set; }
		public int DayId { get; set; }
		public Day Day { get; set; }
	}
}
