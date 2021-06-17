﻿using Microsoft.EntityFrameworkCore;
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
		public async Task Booking_Returns_True()
		{
			var result = await BookingService.PlaceBookingAsync("a@b.dk", 10, DateTime.Now,0,0);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task Booking_Full_Returns_False()
		{
			var result = await BookingService.PlaceBookingAsync("a@b.dk", 10, DateTime.Now,0,0);
			Assert.IsTrue(result);
			var result2 = await BookingService.PlaceBookingAsync("a2@b.dk", 10, DateTime.Now,0,0);
			Assert.IsFalse(result2);
		}
		[Test]
		public async Task Booking_Zero_tables_Booked_On_Freshday()
		{
			var result = await BookingService.CalculateBookedTables(new DateTime(2020, 12, 24, 20, 00, 00));
			Assert.AreEqual(0, result);
		}

		[Test]
		public async Task Booking_Returns_two_tables_booked_when_two_is_booked()
		{
			//better to have used a test case, but oh well
			DateTime now = DateTime.Now;
			await BookingService.PlaceBookingAsync("asd@asd.dk", 2, now, 0, 0);
			var result = await BookingService.CalculateBookedTables(now);
			Assert.AreEqual(2, result);
		}
	}
}
