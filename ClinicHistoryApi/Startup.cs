using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Security.Cryptography.X509Certificates;
using ClinicHistoryApi.Configuration;


namespace ClinicHistoryApi
{
	public class Startup
	{	
		private IConfigurationRoot Configuration { get; }
		private IHostingEnvironment Environment { get; }

		private readonly ILoggerFactory _loggerFactory;
		private readonly AppSettingsOptions _settings;

		public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.Build();

			Environment = env;
			_loggerFactory = loggerFactory;
			_settings = Configuration.GetSection("AppSettings").Get<AppSettingsOptions>();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddConfigureOptions(Configuration)
				.ConfigureAspNetIdentity(Configuration.GetConnectionString("ClinicHistory"))
				.InjectDbContext(Configuration.GetConnectionString("ClinicHistory"));

			services.AddAutoMapper();

			services.AddCors();			
			
			services.InjectDbContext(Configuration.GetConnectionString("ClinicHistory"));

			ConfigureLogging(_loggerFactory);

			var cert = new X509Certificate2(Convert.FromBase64String(Configuration["SigningCertificate"]), "",
				X509KeyStorageFlags.MachineKeySet);

			var idpSettings = new IdentityServerConfig(_settings);

			services.AddIdentityServer()
			  .AddSigningCredential(cert)
			  .AddInMemoryIdentityResources(idpSettings.GetIdentityResources())
			  .AddInMemoryApiResources(idpSettings.GetApiResources())
			  .AddInMemoryClients(idpSettings.GetClients())
			  .AddAspNetIdentity<IdentityUser>();

			services.AddMvc();

			services.AddAuthentication("Bearer")
				  .AddIdentityServerAuthentication(options =>
				  {
					  options.Authority = _settings.AutorityUrl;
					  options.ApiName = "patients";
					  options.ApiSecret = "patientsSecret";
					  options.SupportedTokens = SupportedTokens.Both;
				  });

			var patientsPolicy = new AuthorizationPolicyBuilder()
			   .RequireAuthenticatedUser()
			   .RequireClaim("scope", "patients")
			   .Build();

			services.AddAuthorization(options =>
			{			
				options.AddPolicy("patients", policyUser =>
				{
					policyUser.RequireClaim("scope", "patients");
				});

			});
			
			services.AddDependencies();
		}

		public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
		{
			if (Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentityServer();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseCors(builder =>
				builder.WithOrigins(_settings.ClientUrl)
				.AllowAnyHeader()
				.AllowAnyMethod()				
				.AllowCredentials());

			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();			
		}

		private void ConfigureLogging(ILoggerFactory loggerFactory)
		{
			var serilog = new LoggerConfiguration()
				.ReadFrom
				.Configuration(Configuration);
			const string seqServerAddress = "http://localhost:5341";
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			serilog
				.WriteTo.RollingFile("logs/log-{Date}.txt", LogEventLevel.Information)
				.WriteTo.Seq(seqServerAddress);

			loggerFactory.AddSerilog(serilog.CreateLogger());
		}
	}
}
