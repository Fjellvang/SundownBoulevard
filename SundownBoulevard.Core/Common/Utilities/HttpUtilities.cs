using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Common.Utilities
{
	public static class HttpUtilities
	{
		/// <summary>
		/// Utility to add ProblemDetails response.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static BadRequestObjectResult BadRequestResult(string title, string message = null)
		{
			return new BadRequestObjectResult(BadRequestProblemDetails(title, message));
		}
		public static ProblemDetails BadRequestProblemDetails(string title, string message = null)
		{
			return new ProblemDetails()
			{
				Status = StatusCodes.Status400BadRequest,
				Title = title,
				Detail = message,
			};
		}
	}
}
