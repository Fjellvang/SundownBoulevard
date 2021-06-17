using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SundownBoulevard.Core.Booking.Services;
using SundownBoulevard.Core.Common;
using SundownBoulevard.Core.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookingController : ControllerBase
	{
		private readonly BookingService bookingService;
		private readonly AppSettings settings;

		public BookingController(BookingService bookingService, IOptions<AppSettings> settings)
		{
			this.bookingService = bookingService;
			this.settings = settings.Value;
		}

		[HttpPost(nameof(BookTable))]
		public async Task<IActionResult> BookTable(DateTime day, string email, int hour, int minute, int numberOfGuests)
		{
			if (day.Date < DateTime.Now.Date)
			{
				//we cannot book in the past
				return BadRequest();
			}
			else if (!email.IsValidEmail())
			{
				//supply valid email
				return BadRequest();
			}
			else if (0 > minute || minute > 59)
			{
				return BadRequest();
			}
			else if(settings.OpeningHour > hour || hour > settings.ClosingHour)
			{
				return BadRequest();
			}
			var tablesToBook = (int)Math.Ceiling((double)numberOfGuests / 2);
			if (tablesToBook > settings.TotalTables)
			{
				return BadRequest();
			}

			var bookingDate = new DateTime(day.Year, day.Month, day.Day, hour, minute, 0);
			var success = await bookingService.PlaceBookingAsync(email, tablesToBook, bookingDate);

			if (success)
			{
				return Ok();
			}

			return BadRequest();

		}
	}
}
