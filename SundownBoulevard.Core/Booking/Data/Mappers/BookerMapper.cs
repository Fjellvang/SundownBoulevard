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
	public class BookerMapper : IEntityTypeConfiguration<Booker>
	{
		public void Configure(EntityTypeBuilder<Booker> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(e => e.Email).HasMaxLength(200).IsRequired();
			builder.HasIndex(e => e.Email).IsUnique();
		}
	}
}
