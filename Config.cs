using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace QuizTower.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles",
                "Your role(s)",
                new [] { "role" }),
            new IdentityResource("country",
                "The country you're living in",
                new List<string>() { "country" })
        };

    public static IEnumerable<ApiResource> ApiResources =>
     new ApiResource[]
         {
             new ApiResource("usermanagementapi",
                 "Auth UserManagement API",
                 new [] { "role", "country" })
             {
                 Scopes = { 
                     "usermanagementapi.fullaccess",
                     "usermanagementapi.read",
                     "usermanagementapi.write"

                 },
                ApiSecrets = { new Secret("apisecret".Sha256()) }
             }
         };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("usermanagementapi.fullaccess"),
                new ApiScope("usermanagementapi.read"),
                new ApiScope("usermanagementapi.write")
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client()
                {
                    ClientName = "AuthUserManagement",
                    ClientId = "usermanagementclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 120,
                    // AuthorizationCodeLifetime = ...
                    // IdentityTokenLifetime = ...
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "usermanagementapi.read",
                        "usermanagementapi.write",
                        "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }, 
                    RequireConsent = true
                }
            };
}