using System.IO;
using ClinicHistoryApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicHistoryApi.Data
{
	public class EntitiesDbContext : DbContext
	{
		private IConfigurationRoot Configuration { get; }

		public DbSet<Diagnostic> Diagnostic { get; set; }

		public DbSet<SocialSecurity> SocialSecurity { get; set; }

		public DbSet<Patient> Patient { get; set; }

		public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options)
			: base(options)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("entities");

			modelBuilder.Entity<Patient>().HasKey(x => x.Id);
			modelBuilder.Entity<Patient>().HasIndex(x => x.Name);
			modelBuilder.Entity<Patient>().HasIndex(x => x.LastName);
			modelBuilder.Entity<Patient>().HasIndex(x => x.IdentificationNumber);

			modelBuilder.Entity<Diagnostic>().HasKey(x => x.Id);		
			modelBuilder.Entity<Diagnostic>()
				.HasIndex(x => x.Name)
				.IsUnique();

			modelBuilder.Entity<SocialSecurity>().HasKey(x => x.Id);
			modelBuilder.Entity<SocialSecurity>()
				.HasIndex(x => x.Name)
				.IsUnique();


			modelBuilder.Entity<Consultation>().Property(x => x.Alimentation).HasField("_alimentation");
			modelBuilder.Entity<Consultation>().Property(x => x.Comments).HasField("_comments");
			modelBuilder.Entity<Consultation>().Property(x => x.ComplementaryMethodRequested).HasField("_complementaryMethodRequested");
			modelBuilder.Entity<Consultation>().Property(x => x.Date).HasField("_date");
			modelBuilder.Entity<Consultation>().Property(x => x.DefecatoryHabit).HasField("_defecatoryHabit");
			modelBuilder.Entity<Consultation>().Property(x => x.Evolution).HasField("_evolution");
			modelBuilder.Entity<Consultation>().Property(x => x.Length).HasField("_length");
			modelBuilder.Entity<Consultation>().Property(x => x.PhysicalActivity).HasField("_physicalActivity");
			modelBuilder.Entity<Consultation>().Property(x => x.PhysicalExam).HasField("_physicalExam");
			modelBuilder.Entity<Consultation>().Property(x => x.SchoolPerformance).HasField("_schoolPerformance");
			modelBuilder.Entity<Consultation>().Property(x => x.Weight).HasField("_weight");			

			modelBuilder.Entity<Consultation>().Property(x => x.PatientId)
				.HasField("_patientId")
				.HasColumnName("PatientId");

			modelBuilder.Entity<Consultation>().Property(x => x.PatientId).IsRequired();
			modelBuilder.Entity<Consultation>().HasIndex(x => x.PatientId);


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
