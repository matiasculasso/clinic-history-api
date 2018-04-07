using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ClinicHistoryApi.Auth
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebHost.CreateDefaultBuilder()
			  .UseStartup<Startup>()
			  .Build()
			  .Run();
		}

		// this method is used only by entity framework to run the migrations
		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)				
				.UseEnvironment("desing")
				.UseStartup<Startup>()
				.Build();
	}
}
