using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SundownBoulevard.Core.Booking.Data;
using SundownBoulevard.Core.Booking.Services;
using SundownBoulevard.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Tests.BookingTests
{
	[TestFixture]
	public class BookingTests
	{
		public BookingService BookingService { get; set; }
		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<SundownBoulevardDbContext>()
							  .UseInMemoryDatabase(Guid.NewGuid().ToString())
							  .Options;

			var settings = new AppSettings()
			{
				TotalTables = 10
			};

			BookingService = new BookingService(new SundownBoulevardDbContext(options), settings);
		}

		[Test]
		public void is_True()
		{
			Assert.IsTrue(true);
		}

		[Test]
		public async Task Booking_Returns_True()
		{
			var result = await BookingService.PlaceBookingAsync("a@b.dk", 10, DateTime.Now);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task Booking_Full_Returns_False()
		{
			var result = await BookingService.PlaceBookingAsync("a@b.dk", 10, DateTime.Now);
			Assert.IsTrue(result);
			var result2 = await BookingService.PlaceBookingAsync("a2@b.dk", 10, DateTime.Now);
			Assert.IsFalse(result2);
		}
	}
}
