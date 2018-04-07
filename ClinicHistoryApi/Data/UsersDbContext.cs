using System.IO;
using ClinicHistoryApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicHistoryApi.Data
{
	public class UsersDbContext : IdentityDbContext<IdentityUser>
	{
		private IConfigurationRoot Configuration { get; }

		public UsersDbContext(DbContextOptions<UsersDbContext> options)
			: base(options)
		{

			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{		
			modelBuilder.HasDefaultSchema("users");
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) return;

			var connectionString = Configuration.GetConnectionString("ClinicHistory");
			optionsBuilder.UseSqlServer(connectionString, o => o.MigrationsAssembly("ClinicHistoryApi"));
		}
	}
}
