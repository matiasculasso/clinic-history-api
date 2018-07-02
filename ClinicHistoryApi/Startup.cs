using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography.X509Certificates;
using ClinicHistoryApi.Configuration;
using ClinicHistoryApi.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Swagger;


namespace ClinicHistoryApi
{
	public class Startup
	{
		private IConfigurationRoot Configuration { get; }
		private IHostingEnvironment Environment { get; }

		private readonly AppSettingsOptions _settings;

		public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.Build();

			Environment = env;
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

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Clinic History API", Version = "v1" });
			});

			services.AddAuthentication("Bearer")
				.AddIdentityServerAuthentication(options =>
				{
					options.RequireHttpsMetadata = false;
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
			ConfigureLoggin();
		}

		public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
		{
			app.UseDeveloperExceptionPage();

			app.UseIdentityServer();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseCors(builder =>
				builder.WithOrigins(_settings.ClientUrl)
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials());

			app.UseAuthentication();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic History API V1");
			});

			app.UseMiddleware<ErrorLoggingMiddleware>();

			app.UseMvcWithDefaultRoute();

			Log.Information("Updating database");
			UpdateDatabase(app);
			Log.Information("Database updated correctly");

			Log.Information("Application Configured correctly");
		}

		private void ConfigureLoggin()
		{
			var connectionString = Configuration.GetConnectionString("ClinicHistory");
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.FromLogContext()
				.WriteTo.MSSqlServer(connectionString, "ClinicHistoryLogs", schemaName: "entities")
				.WriteTo.Console()
				.CreateLogger();

			Log.Information("Getting the motors running...");
		}

		private static void UpdateDatabase(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices
				.GetRequiredService<IServiceScopeFactory>()
				.CreateScope())
			{
				using (var context = serviceScope.ServiceProvider.GetService<EntitiesDbContext>())
				{
					context.Database.Migrate();
				}
				using (var context = serviceScope.ServiceProvider.GetService<UsersDbContext>())
				{
					context.Database.Migrate();
				}
			}
		}
	}
}
