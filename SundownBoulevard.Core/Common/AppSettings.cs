using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Common
{
	public class AppSettings
	{
		/// <summary>
		/// total tables in the restaurant
		/// </summary>
		public int TotalTables { get; set; }
		/// <summary>
		/// the total hours a table can be booked
		/// </summary>
		public int TotalHoursBooked { get; set; }
	}
}
