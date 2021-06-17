using Microsoft.AspNetCore.Http;
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
using static SundownBoulevard.Core.Common.Utilities.HttpUtilities;

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
		public async Task<IActionResult> BookTable(DateTime day, string email, int hour, int minute, int numberOfGuests, int foodMenu, int beerMenu)
		{
			if (day.Date < DateTime.Now.Date)
			{
				//we cannot book in the past
				return BadRequestResult("You cannot book in the past");
			}
			else if (!email.IsValidEmail())
			{
				//supply valid email
				return BadRequestResult("please supply a valid email");
			}
			else if (0 > minute || minute > 59)
			{
				return BadRequestResult("minute format invalid");
			}
			else if(settings.OpeningHour > hour || hour > settings.ClosingHour)
			{
				return BadRequestResult("hour out side of opening hours");
			}
			var tablesToBook = (int)Math.Ceiling((double)numberOfGuests / 2);
			if (tablesToBook > settings.TotalTables)
			{
				return BadRequestResult("Not enough tables in the restaurant to handle your request");
			}

			var bookingDate = new DateTime(day.Year, day.Month, day.Day, hour, minute, 0);
			var success = await bookingService.PlaceBookingAsync(email, tablesToBook, bookingDate, beerMenu, foodMenu);

			if (success)
			{
				return Ok();
			}
			return BadRequestResult("Sorry the restaurant is fully booked");
		}
	}
}
