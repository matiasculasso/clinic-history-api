﻿using System.Reflection;
using ClinicHistoryApi.Data;
using ClinicHistoryApi.Services;
using ClinicHistoryApi.Services.Intefaces;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicHistoryApi.Configuration
{
	public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();			
			services.AddScoped<IProfileService, ProfileService>();
			services.AddTransient<IGenericService, GenericService>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();

	        services.AddTransient<UserStore<IdentityUser>, UserStore<IdentityUser>>();

			return services;
        }

		public static IServiceCollection InjectDbContext(this IServiceCollection serviceCollection, string connectionString)
		{
			var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
			serviceCollection.AddDbContext<EntitiesDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly)));
			return serviceCollection;
		}

	    public static IServiceCollection AddConfigureOptions(this IServiceCollection services, IConfigurationRoot configuration)
	    {
		    services.AddOptions();
		    services.Configure<AppSettingsOptions>(configuration.GetSection("AppSettings"));		   
		    services.AddSingleton<IConfiguration>(configuration); //globally available config object thru DI.
		    return services;
	    }

	    public static IServiceCollection ConfigureAspNetIdentity(this IServiceCollection services, string connectionString)
	    {
		    var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

		    services.AddDbContext<UsersDbContext>(options =>
			    options.UseSqlServer(connectionString, o => o.MigrationsAssembly(migrationsAssembly)));

		    services.AddIdentity<IdentityUser, IdentityRole>()
			    .AddEntityFrameworkStores<UsersDbContext>()
			    .AddDefaultTokenProviders();

		    return services;
	    }	   
	}
}
