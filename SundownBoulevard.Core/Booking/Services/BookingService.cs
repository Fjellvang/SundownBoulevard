using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SundownBoulevard.Core.Booking.Data;
using SundownBoulevard.Core.Booking.Data.Entities;
using SundownBoulevard.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Services
{
	public class BookingService 
	{
		private readonly SundownBoulevardDbContext context;
		private readonly AppSettings settings;
		//Overload for testing..
		//TODO: replace with a mock in tests instead..
		public BookingService(SundownBoulevardDbContext context, AppSettings settings)
		{
			this.context = context;
			this.settings = settings;
		}

		public BookingService(SundownBoulevardDbContext context, IOptions<AppSettings> settings)
		{
			this.context = context;
			this.settings = settings.Value;
		}

		public Task<int> CalculateBookedTables(DateTime date)
		{
			var data = GetDateAndTicksFromDateTime(date);
			return CalculateBookedTables(data.date, data.startTimeTicks, data.endTimeTicks);
		}
		private Task<int> CalculateBookedTables(DateTime date, long startTimeTicks, long endTimeTicks)
		{
			return context.Orders
				.Where(x => x.Day.Date.Date == date &&
					x.BookingStartTicks <= startTimeTicks && startTimeTicks < x.BookingEndTicks ||
					x.BookingStartTicks <= endTimeTicks && endTimeTicks < x.BookingEndTicks)
				.SumAsync(x => x.NumberOfTables);
		}

		/// <summary>
		/// helper to get ticks and date from a datetime
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		private (DateTime date, long startTimeTicks, long endTimeTicks) GetDateAndTicksFromDateTime(DateTime time)
		{
			var date = time.Date;
			var startTimeTicks = time.Ticks;
			var endTimeTicks = time.AddHours(2).Ticks;
			return (date, startTimeTicks, endTimeTicks);
		}

		public Task GetBookingsAsync(string email)
		{
			throw new NotImplementedException();
			//context.Bookers.Where(x => x.Email == email)
		}

		/// <summary>
		/// Places a booking, return indicate wheter we can book or not
		/// </summary>
		/// <param name="email">email of the user</param>
		/// <param name="requiredTables">the number of tables a booking requires.</param>
		/// <param name="time">booking time</param>
		/// <returns></returns>
		public async Task<bool> PlaceBookingAsync(string email, int requiredTables, DateTime time, int beerMenu, int foodMenu)
		{
			var (date, startTimeTicks, endTimeTicks) = GetDateAndTicksFromDateTime(time);
			var bookedTables = await CalculateBookedTables(date, startTimeTicks, endTimeTicks);				

			if (bookedTables + requiredTables > settings.TotalTables)
			{
				return false; // restaurant full.
			}

			var booker = await GetOrCreateBookerAsync(email);
			var day = await GetOrCreateDayAsync(date);

			context.Add(new Order()
			{
				Booker = booker,
				Day = day,
				BookingStartTicks = startTimeTicks,
				BookingEndTicks = endTimeTicks,
				NumberOfTables = requiredTables,
				ChosenBeerId = beerMenu,
				ChosenMenuId = foodMenu
			});

			await context.SaveChangesAsync();

			return true;
		}

		private async Task<Booker> GetOrCreateBookerAsync(string email)
		{
			var booker = await context.Bookers.FirstOrDefaultAsync(x => x.Email == email);
			if (booker is null)
			{
				booker = new Booker()
				{
					Email = email
				};
				context.Add(booker);
			}
			return booker;
		}

		private async Task<Day> GetOrCreateDayAsync(DateTime date)
		{
			var day = await context.Days.FirstOrDefaultAsync(x => x.Date.Date.Date == date); //Date.date.dat how horrible..
			if (day is null)
			{
				day = new Day()
				{
					Date = date.Date
				};
				context.Add(day);
			}
			return day;
		}
	}
}
