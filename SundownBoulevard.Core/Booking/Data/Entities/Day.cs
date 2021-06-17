﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Data.Entities
{
	public class Day
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }

		public IEnumerable<Order> Orders { get; set; }
	}
}
