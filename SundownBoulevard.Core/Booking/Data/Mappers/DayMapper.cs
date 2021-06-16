using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SundownBoulevard.Core.Booking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Booking.Data.Mappers
{
	public class DayMapper : IEntityTypeConfiguration<Day>
	{
		public void Configure(EntityTypeBuilder<Day> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(e => e.Date).IsRequired();
		}
	}
}
