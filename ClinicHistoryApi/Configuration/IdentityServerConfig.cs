using IdentityServer4.Models;
using System.Collections.Generic;

namespace ClinicHistoryApi.Configuration
{

	public class IdentityServerConfig
	{
		private readonly AppSettingsOptions _settings;

		public IdentityServerConfig(AppSettingsOptions settings)
		{
			_settings = settings;
		}

		public IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email()
			};
		}

		public IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("patients")
				{
					ApiSecrets =
					{
						new Secret("patientsSecret".Sha256())
					},
					Scopes =
					{
						new Scope
						{
							Name = "patientsRecordsscope",
							DisplayName = "Scope for the patientsRecords ApiResource"
						}
					}
				}
			};
		}

		// clients want to access resources (aka scopes)
		public IEnumerable<Client> GetClients()
		{
			// client credentials client
			return new List<Client>
			{
				new Client
				{
					ClientName = "clinic-hitstory",
					ClientId = "clinic-hitstory",
					AccessTokenType = AccessTokenType.Reference,
                    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                    AllowedGrantTypes = GrantTypes.Implicit,
					RequireConsent = false,
					AllowAccessTokensViaBrowser = true,
					RedirectUris = new List<string>
					{
						_settings.ClientUrl
					},
					PostLogoutRedirectUris = new List<string>
					{
						_settings.ClientUrl
					},
					AllowedCorsOrigins = new List<string>
					{
						_settings.ClientUrl
					},
					AllowedScopes = new List<string>
					{
						"openid",
						"patients",
						"profile"
					}
				}
			};
		}
	}
}