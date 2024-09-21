using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using QuizTower.IDP.Util;
using Serilog;
using static QuizTower.IDP.Config;
using static System.Net.WebRequestMethods;

namespace QuizTower.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "Your role(s)", new [] { "role" }),
                new IdentityResource("country", "The country you're living in", new List<string>() { "country" })
            };

    // Note: Using 'ApiResources' allows for greater flexibility. For instance, different client applications can be granted various levels of access within the API. For example, a mobile client can be given access to the read scope, while a web client can be granted read and write access or even full access.
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
            {
                new ApiResource("usermanagementapi", "User Management System Backend",
                    new []
                    {
                        "role",
                        "country"
                    })
                {
                    Scopes =
                    {
                        "usermanagementapi.fullaccess",
                        "usermanagementapi.read",
                        "usermanagementapi.write"
                    },
                    ApiSecrets = { new Secret("apisecret".Sha256()) }
                },
                new ApiResource("towerofquizzesapi", "Tower of Quizzes Default Backend",
                    new []
                    {
                        "role",
                        "country"
                    })
                {
                    Scopes =
                    {
                        "towerofquizzesapi.fullaccess",
                        "towerofquizzesapi.read",
                        "towerofquizzesapi.write"
                    },
                    ApiSecrets = { new Secret("apisecret".Sha256()) }
                },
                new ApiResource("towerofquizzesbffapi", "Tower of Quizzes BFF Backend",
                    new []
                    {
                        "role",
                        "country"
                    })
                {
                    Scopes =
                    {
                        "towerofquizzesbffapi.fullaccess",
                        "towerofquizzesbffapi.read",
                        "towerofquizzesbffapi.write"
                    },
                    ApiSecrets = { new Secret("bffapisecret".Sha256()) }
                }
            };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("usermanagementapi.fullaccess"),
                new ApiScope("usermanagementapi.read"),
                new ApiScope("usermanagementapi.write"),
                new ApiScope("towerofquizzesapi.fullaccess"),
                new ApiScope("towerofquizzesapi.read"),
                new ApiScope("towerofquizzesapi.write"),
                new ApiScope("towerofquizzesbffapi.fullaccess"),
                new ApiScope("towerofquizzesbffapi.read"),
                new ApiScope("towerofquizzesbffapi.write")
            };

    public static IEnumerable<Client> Clients(IConfiguration configuration, IWebHostEnvironment env)
    {
        foreach (var e in configuration.GetSection("SwaggerClients").GetChildren()
                     .Select(client => client.Get<SwaggerClientConfig>())!
                     .ValidateClients(env)
                     .Select(config => new Client
                     {
                         Enabled = config.EnabledBool,
                         ClientId = config.ClientId,
                         ClientName = config.ClientName,
                         ClientSecrets = { new Secret(config.Secret.Sha256()) },
                         AllowedGrantTypes = config.AllowedGrantTypes.Distinct().ToArray(),
                         RequireClientSecret = !string.IsNullOrEmpty(config.Secret),
                         RequirePkce = true,
                         RedirectUris = { config.RedirectUri },
                         AllowedCorsOrigins = { config.Host },
                         AllowOfflineAccess = config.AllowOfflineAccess ?? false,
                         AllowedScopes = config.AllowedScopes ?? new[] { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                         PostLogoutRedirectUris = config.PostLogoutRedirectUris ?? new[] { $"{config.Host}/" },
                         AccessTokenType = AccessTokenType.Reference
                     }))
        {
            yield return e;
        }

        foreach (var e in configuration.GetSection("Clients").GetChildren()
                     .Select(client => client.Get<ClientConfig>())!
                     .ValidateClients(env)
                     .Select(config =>
                     {
                         var c = new Client();
                         c.Enabled = config.EnabledBool;
                         c.ClientId = config.ClientId ?? c.ClientId;
                         c.ClientName = config.ClientName ?? c.ClientName;
                         c.ClientSecrets = config.ClientSecrets?.Select(s => new Secret(s.Sha256()))?.ToList() ?? c.ClientSecrets;
                         c.RequireClientSecret = config.RequireClientSecret ?? c.RequireClientSecret;
                         c.AllowedGrantTypes = config.AllowedGrantTypes ?? c.AllowedGrantTypes;
                         c.RequirePkce = config.RequirePkce ?? c.RequirePkce;
                         c.RedirectUris = config.RedirectUris ?? c.RedirectUris;
                         c.AllowedCorsOrigins = config.AllowedCorsOrigins ?? c.AllowedCorsOrigins;
                         c.AllowedScopes = config.AllowedScopes ?? c.AllowedScopes;
                         c.AllowOfflineAccess = config.AllowOfflineAccess ?? c.AllowOfflineAccess;
                         c.AbsoluteRefreshTokenLifetime = config.AbsoluteRefreshTokenLifetime ?? c.AbsoluteRefreshTokenLifetime;
                         c.AccessTokenLifetime = config.AccessTokenLifetime ?? c.AccessTokenLifetime;
                         c.IdentityTokenLifetime = config.IdentityTokenLifetime ?? c.IdentityTokenLifetime;
                         c.PostLogoutRedirectUris = config.PostLogoutRedirectUris ?? c.PostLogoutRedirectUris;

                         // Add FrontChannelLogoutUri and BackChannelLogoutUri
                         c.FrontChannelLogoutUri = config.FrontChannelLogoutUri ?? c.FrontChannelLogoutUri;
                         c.BackChannelLogoutUri = config.BackChannelLogoutUri ?? c.BackChannelLogoutUri;

                         // Additional properties
                         c.UserSsoLifetime = 60 * 60 * 12; //12 uur
                         c.Properties = new Dictionary<string, string>();

                         if (!string.IsNullOrEmpty(config.ClientHomeUrl))
                             c.Properties["ClientHomeUrl"] = config.ClientHomeUrl;

                         c.UpdateAccessTokenClaimsOnRefresh = true;
                         c.RefreshTokenUsage = TokenUsage.OneTimeOnly;
                         c.AccessTokenType = AccessTokenType.Reference;

                         return c;
                     }))
        {
             yield return e;
        }

        ////// Note: GetHardcodedClients instead of AppSettings, for debug purpose.
        ////foreach (var client in GetHardcodedClients())
        ////{
        ////    yield return client;
        ////}
    }

    private static IEnumerable<Client> GetHardcodedClients()
    {
        return new List<Client>
        {
            new Client()
            {
                ClientName = "User Management System",
                ClientId = "usermanagementclient",
                AllowedGrantTypes = GrantTypes.Code, // GrantTypes.CodeAndClientCredentials
                AccessTokenType = AccessTokenType.Reference,
                AllowOfflineAccess = true,
                AbsoluteRefreshTokenLifetime = 3600 * 24 * 30,
                SlidingRefreshTokenLifetime = 3600 * 24 * 15,
                UpdateAccessTokenClaimsOnRefresh = true,
                // IdentityTokenLifetime = ...
                // AuthorizationCodeLifetime = ... // During code-flow
                AccessTokenLifetime = 120, // out-of-sync 120sec (server uses always minimum 5minutes.)
                RedirectUris =
                {
                    // Note: we need to add a valid URI, so this client is allowed to receive tokens on. That URI is the host address of our Client web application followed by signin-oidc. 
                    "https://localhost:7184/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    // Note: this URI is used by web app client to signout from the IDP middleware and redirect back to a page. This signout must by catch by the web app client (SignedOutCallbackPath).
                    "https://localhost:7184/signout-callback-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    "country",
                    "usermanagementapi.read",
                    "usermanagementapi.write",
                    "offline_access"
                },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                }, 
                // RequireConsent = true // Consent screen is handy for development otherwise, just disable it.
            },
            new Client()
            {
                ClientName = "Tower of Quizzes BFF Angular SPA",
                ClientId = "towerofquizzesbff",
                AllowedGrantTypes = GrantTypes.Code,
                AccessTokenType = AccessTokenType.Reference,
                AllowOfflineAccess = true,
                AbsoluteRefreshTokenLifetime = 3600 * 24 * 30,
                SlidingRefreshTokenLifetime = 3600 * 24 * 15,
                UpdateAccessTokenClaimsOnRefresh = true,
                AccessTokenLifetime = 3600,
                RedirectUris =
                {
                    "https://localhost:44365/signin-oidc"
                },
                FrontChannelLogoutUri = "https://localhost:44365/signout-oidc", // Note: The FrontChannelLogoutUri is designed to function within an iframe (client-side), which must be present and available in frontend web browsers for proper functionality.
                BackChannelLogoutUri = "https://localhost:44365/account/backchannel", // Note: The BackChannelLogoutUri operates on the server-side, where the logout process can be executed.
                PostLogoutRedirectUris =
                {
                    "https://localhost:44365/signout-callback-oidc"
                },
                // AlwaysIncludeUserClaimsInIdToken = true, // Note: That all claims should be put in the identity token.
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    "country",
                    "towerofquizzesapi.read",
                    "towerofquizzesapi.write",
                    "towerofquizzesbffapi.read",
                    "towerofquizzesbffapi.write",
                    "offline_access"
                },
                ClientSecrets =
                {
                    new Secret("bffclientsecret".Sha256())
                },
                RequireConsent = false
            }
        };
    }

    public class SwaggerClientConfig
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Host { get; set; }
        public string RedirectUri { get; set; }
        public string Secret { get; set; }
        public string[] AllowedScopes { get; set; }
        public string[] AllowedGrantTypes { get; set; }
        public bool? AllowOfflineAccess { get; set; }
        public string Enabled { get; set; }
        public bool EnabledBool => "true".Equals(Enabled, StringComparison.InvariantCultureIgnoreCase);
        public string[] PostLogoutRedirectUris { get; set; }
    }

    public class ClientConfig
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string[] ClientSecrets { get; set; }
        public string[] AllowedGrantTypes { get; set; }
        public bool? RequirePkce { get; set; }
        public bool? RequireClientSecret { get; set; }
        public string ClientHomeUrl { get; set; }
        public string[] RedirectUris { get; set; }
        public string[] AllowedCorsOrigins { get; set; }
        public string[] AllowedScopes { get; set; }
        public bool? AllowOfflineAccess { get; set; }
        public int? AbsoluteRefreshTokenLifetime { get; set; }
        public int? AccessTokenLifetime { get; set; }
        public int? IdentityTokenLifetime { get; set; }
        public string[] PostLogoutRedirectUris { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public string BackChannelLogoutUri { get; set; }
        public string Enabled { get; set; }
        public bool EnabledBool => "true".Equals(Enabled, StringComparison.InvariantCultureIgnoreCase);
    }

    public class ApiScopeConfig
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}

public static class ClientExtensions
{
    public static IEnumerable<Config.ClientConfig> ValidateClients(this IEnumerable<Config.ClientConfig> clients, IWebHostEnvironment env)
    {
        return clients.Where(c => c.EnabledBool).Select(client =>
        {
            if (client.AllowedGrantTypes == null || !client.AllowedGrantTypes.Any())
                throw new InvalidClientConfigException(client.ClientId, "Client does not have AllowedGrantTypes");

            if (client.AllowedGrantTypes.Select(gt => gt.ToLower()).Any(gt => gt == "client_credentials"))
            {
                if (!client.ClientSecrets.Any())
                    throw new InvalidClientConfigException(client.ClientId, "Client does not have secrets");
                foreach (var secret in client.ClientSecrets)
                    ValidateSecret(client.ClientId, secret, env);
            }

            if (client.AllowedGrantTypes.Select(gt => gt.ToLower()).Any(gt => gt == "authorization_code"))
            {
                if (!client.AllowedScopes.Contains("openid"))
                    throw new InvalidClientConfigException(client.ClientId, "Scope 'openid' is missing");
            }

            return client;
        });
    }

    public static IEnumerable<Config.SwaggerClientConfig> ValidateClients(this IEnumerable<Config.SwaggerClientConfig> clients, IWebHostEnvironment env)
    {
        return clients.Where(c => c.EnabledBool).Select(client =>
        {
            if (client.AllowedGrantTypes == null || !client.AllowedGrantTypes.Any())
                throw new InvalidClientConfigException(client.ClientId, "Client does not have AllowedGrantTypes");

            if (client.AllowedGrantTypes.Select(gt => gt.ToLower()).Any(gt => gt == "client_credentials"))
            {
                ValidateSecret(client.ClientId, client.Secret, env);
            }

            if (client.AllowedGrantTypes.Select(gt => gt.ToLower()).Any(gt => gt == "authorization_code"))
            {
                if (client.AllowOfflineAccess is null or false)
                    Log.Logger.Warning($"Warning: in the appsettings configuration for client '{client.ClientId}' " +
                                           "AllowOfflineAccess is disabled, so refresh tokens cannot be used.");

                if (!client.AllowedScopes.Contains("openid"))
                    throw new InvalidClientConfigException(client.ClientId, "Scope 'openid' is missing");
            }

            return client;
        });
    }

    private static void ValidateSecret(string clientId, string secret, IWebHostEnvironment env)
    {
        if (secret == null)
            throw new InvalidClientConfigException(clientId, "Secret is missing");
        if (secret.StartsWith("#{") && secret.EndsWith("}"))
            throw new InvalidClientConfigException(clientId, $"Invalid secret '{secret}': secret contains deployment variable placeholder");
        //if (env.IsDevelopment() || env.IsTest())
        //    if (secret is "dit_is_geheim" or "secret")
        //        return;
        //if (secret.Length < 20)
        //throw new InvalidClientConfigException(clientId, $"Invalid secret '{secret}': secret must be at least 20 characters long.");
    }
}

public class InvalidClientConfigException : Exception
{
    public InvalidClientConfigException(string clientId, string message) : base($"Invalid configuration for client '{clientId}': {message}")
    {
    }
}
