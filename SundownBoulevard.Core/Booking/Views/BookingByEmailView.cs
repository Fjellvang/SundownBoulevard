using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Views
{
	public class BookingByEmailView
	{
		public string Email { get; set; }
		public OrderView[] Orders { get; set; }
	}

	public class OrderView
	{
		public DateTime Date { get; set; }
		public int ChosenMenu { get; set; }
		public int ChosenBeer { get; set; }
		public int NumberOfTables { get; set; }
	}
}
