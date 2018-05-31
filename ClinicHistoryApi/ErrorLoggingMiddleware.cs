using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace ClinicHistoryApi
{
	public class ErrorLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"The following error happened: {ex.Message}");
				throw;
			}
		}
	}
}
