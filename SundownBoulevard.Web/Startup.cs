using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SundownBoulevard.Core.Booking.Data;
using SundownBoulevard.Core.Booking.Services;
using SundownBoulevard.Core.Common;
using SundownBoulevard.Core.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sundown_Boulevard
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.Configure<AppSettings>(Configuration.GetSection("BookingSettings"));
			services.AddDbContext<SundownBoulevardDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("SundownBoulevard")));
			services.AddControllersWithViews();
			services.AddTransient<BookingService>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SundownBoulevardDbContext dbContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			//Lazy mans middleware.
			app.Use(async (context, next) =>
			{
				try
				{
					await next();
				}
				catch (Exception)
				{
					context.Response.StatusCode = 400;
					await context.Response.WriteAsync(JsonSerializer.Serialize(HttpUtilities.BadRequestProblemDetails("An error occured during exection. Staff has been notified"))); // now thats a lie....
					//TODO: can add logging here.
				}
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
			});
			dbContext.Database.Migrate(); // ensure migrations applied
		}
	}
}
