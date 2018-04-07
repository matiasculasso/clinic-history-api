using ClinicHistoryApi.Auth.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

namespace ClinicHistoryApi.Auth
{
	public class AuditLoggerFactory : IAuditLoggerFactory
	{
		private readonly IOptions<AppSettingsOptions> _settings;
		private readonly IConfiguration _configurationRoot;

		public AuditLoggerFactory(IOptions<AppSettingsOptions> settings, IConfiguration configuration)
		{
			_settings = settings;
			_configurationRoot = configuration;
		}

		public Serilog.Core.Logger CreateLogger()
		{
			var connectionString = _configurationRoot.GetConnectionString("ClinicHistory");
			return new LoggerConfiguration()
				.WriteTo
				.MSSqlServer(connectionString, "ClinicHistoryLogs", autoCreateSqlTable: false, schemaName: "domain")
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.Enrich.WithProperty("Application", "ClientHistoryApi")
				.MinimumLevel.Verbose()
				.CreateLogger();
		}

	}

	public interface IAuditLoggerFactory
	{
		Serilog.Core.Logger CreateLogger();
	}
}
