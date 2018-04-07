use ClinicHistory

declare @clientId as varchar(40);
set @clientid = 'clinic-hitstory' 

INSERT [dbo].[Clients] ([AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh], [BackChannelLogoutSessionRequired], [BackChannelLogoutUri], [ClientClaimsPrefix], [ConsentLifetime], [Description], [FrontChannelLogoutSessionRequired], [FrontChannelLogoutUri], [PairWiseSubjectSalt])
VALUES (2592000, 3600, 0, 0, 0, 0, 1, 0, 0, 300, @clientid, @clientid, NULL, 1, 1, 300, 0, NULL, N'oidc', 1, 1, 1, 1, 0, 1296000, 0, 0, NULL, NULL, NULL, NULL, 0, NULL, NULL)

declare @id as int;
set @id = (select top 1 id from clients where clientid =  @clientid);


INSERT [dbo].[ClientGrantTypes] ( [ClientId], [GrantType]) VALUES (@id, N'client_credentials')

INSERT [dbo].[ClientGrantTypes] ( [ClientId], [GrantType]) VALUES (@id, N'implicit')


INSERT [dbo].[ClientPostLogoutRedirectUris] ([ClientId], [PostLogoutRedirectUri]) VALUES (@id, N'http://localhost:14000/signout-callback-oidc')

INSERT [dbo].[ClientRedirectUris] ([ClientId], [RedirectUri]) VALUES (@id, N'http://localhost:14000/signin-oidc')

INSERT [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@id, N'openid')
INSERT [dbo].[ClientScopes] ([ClientId], [Scope]) VALUES (@id, N'profile')

INSERT [dbo].[ClientSecrets] ([ClientId], [Description], [Expiration], [Type], [Value]) VALUES (@id, NULL, NULL, N'SharedSecret', N'Rgmhf/zGDgFlENp88NhDyzueqvDj7/eB4cN7/Sh4dME=')

SET IDENTITY_INSERT [dbo].[IdentityResources] ON 
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, N'', N'OpenID Connect', 0, 1, N'openid', 0, 0)
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (2, N'profile', N'profile', 0, 1, N'profile', 0, 0)
SET IDENTITY_INSERT [dbo].[IdentityResources] OFF

-- username testuser1@itagroup.com password TestUser1$
INSERT [users].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) 
VALUES (N'461276b1-7252-4693-bbd8-1492f899c8db', 0, N'e461a1f7-b80d-4aad-aa45-02ff5c778106', N'testuser1@itagroup.com', 0, 1, NULL, N'TESTUSER1@ITAGROUP.COM', N'TESTUSER1@ITAGROUP.COM', N'AQAAAAEAACcQAAAAEMFqq3h/nfqHRMYPMDb0OhMtb7Reb0gGQwy/aAnsD2zu9DwjmYOKAs5ImjXkZ5nJeg==', NULL, 0, N'689af6b6-5dc4-4773-a727-612373be2c9e', 0, N'testuser1@itagroup.com')
-- username testuser2@itagroup.com password TestUser2$
INSERT [users].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) 
VALUES (N'98d69c31-1ef3-4923-83e9-11660e0f7993', 0, N'b4d70bf6-73b6-4812-937f-4257b3a293af', N'testuser2@itagroup.com', 0, 1, NULL, N'TESTUSER2@ITAGROUP.COM', N'TESTUSER2@ITAGROUP.COM', N'AQAAAAEAACcQAAAAEG7q+nX5zoVgDtr5SseYK2rEVnqXdBm+oS9IgNic67mDmZRkFi8sjtFiX1i2XDkWOQ==', NULL, 0, N'9690abb0-ffb1-4877-9238-a0cf0317236f', 0, N'testuser2@itagroup.com')


