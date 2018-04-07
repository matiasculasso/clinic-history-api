using IdentityServer4.Models;
using System.Collections.Generic;

namespace ClinicHistoryApi.Configuration
{

	public class IdentityServerConfig
	{
		public static string HOST_URL = "http://localhost:1200";

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email()
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
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
		public static IEnumerable<Client> GetClients()
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
						 "http://localhost:4200/"
					},
					PostLogoutRedirectUris = new List<string>
					{
						 "http://localhost:4200/"
					},
					AllowedCorsOrigins = new List<string>
					{
						 "http://localhost:4200"
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