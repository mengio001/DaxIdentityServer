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
                new IdentityResource("roles", "Your role(s)", new [] { "role" }),
                new IdentityResource("country", "The country you're living in", new List<string>() { "country" })
            };

    // Note: Using 'ApiResources' allows for greater flexibility. For instance, different client applications can be granted various levels of access within the API. For example, a mobile client can be given access to the read scope, while a web client can be granted read and write access or even full access.
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
            {
                new ApiResource("usermanagementapi", "User Management System backend", 
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
                new ApiResource("quiztowerapi", "Tower of Quizzes backend", 
                    new []
                    {
                        "role", 
                        "country"
                    })
                {
                    Scopes =
                    {
                        "quiztowerapi.fullaccess",
                        "quiztowerapi.read",
                        "quiztowerapi.write"
                    },
                    ApiSecrets = { new Secret("apisecret".Sha256()) }
                }
            };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("usermanagementapi.fullaccess"),
                new ApiScope("usermanagementapi.read"),
                new ApiScope("usermanagementapi.write"),
                new ApiScope("quiztowerapi.fullaccess"),
                new ApiScope("quiztowerapi.read"),
                new ApiScope("quiztowerapi.write")
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
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
                    AccessTokenLifetime = 120, // out-of-sync 120sec (server uses always minimum 5minutes.) // todo: resolve refreshToken issue
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
                    ClientName = "Tower of Quizzes Angular ClientApp",
                    ClientId = "quiztowerclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    AllowOfflineAccess = true,
                    AbsoluteRefreshTokenLifetime = 3600 * 24 * 30,
                    SlidingRefreshTokenLifetime = 3600 * 24 * 15,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    // IdentityTokenLifetime = ...
                    // AuthorizationCodeLifetime = ... // During code-flow
                    AccessTokenLifetime = 3600,
                    RedirectUris =
                    {
                        "https://localhost:4200/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:4200/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "country",
                        "quiztowerapi.read",
                        "quiztowerapi.write",
                        "offline_access"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }, 
                    // RequireConsent = true // Consent screen (opt-in checkbox) is handy for development otherwise, just disable it.
                }
            };
}