using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizTower.IDP.DbContexts;
using QuizTower.IDP.Services;
using Serilog;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using QuizTower.IDP.Models;
using QuizTower.IDP.Util;
using QuizTower.IDP.PasswordValidators;
using QuizTower.IDP.Entities;

namespace QuizTower.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // IISOptions will be used on launchProfile: IIS Express (local hosting / "ASPNETCORE_ENVIRONMENT": "Development")
        builder.Services.Configure<IISOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });

        // IISServerOptions will be used when hosting with Kestrel behind local hosting IIS
        builder.Services.Configure<IISServerOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });

        //var options = new DefaultAzureCredentialOptions
        //{
        //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //    TenantId = "5692e72c-b118-45bb-8575-47c1c00b31ed"
        //};
        // note: AddDataProtection key will be stored in Azure Blob Storage, and we'll protect it with a key stored in KeyVault.
        // wiki: https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview?view=aspnetcore-8.0
        //var azureCredential = new DefaultAzureCredential(options);

        //builder.Services.AddDataProtection()
        //    .PersistKeysToAzureBlobStorage(new Uri(builder.Configuration["DataProtection:Keys"]), azureCredential)
        //    .ProtectKeysWithAzureKeyVault(new Uri(builder.Configuration["DataProtection:ProtectionKeyForKeys"]), azureCredential);

        // Instead of CertificateClient I am going to use SecretClient to get secrets from KeyVault (private and public to support signingCertificate.
        // GetCertificate() -> With this call we will get certificate info and public, with public key we can validate a signature or encrypt something.
        // But for signing we need also private key (sign tokens) of RSA so instead of new CertificateClient() I'll use new SecretClient()

        //var certificateClient = new CertificateClient(new Uri(builder.Configuration["KeyVault : RootUri"]), azureCredential);
        //var certificateResponse = certificateClient.GetCertificate(builder.Configuration["KeyVault:CertificateName"]);

        // Example properties/details (three related resources) of Azure certificate in KeyVault (RSA):
        // - certificate resource (public key, metadata)
        // - key resource (private key)
        // - secret resource (full certificate: certificate resource and private key)

        //var secretClient = new SecretClient(new Uri(builder.Configuration["KeyVault:RootUri"]), azureCredential);
        //var secretResponse = secretClient.GetSecret(builder.Configuration["KeyVault:CertificateName"]);

        //var signingCertificate = new X509Certificate2(Convert.FromBase64String(secretResponse.Value.Value), (string)null, X509KeyStorageFlags.MachineKeySet);

        builder.Services.AddRazorPages();

        builder.Services.AddScoped<IPasswordHasher<Entities.AspNetUser>, PasswordHasher<Entities.AspNetUser>>();

        builder.Services.AddScoped<ILocalUserService, LocalUserService>();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

        // Note: Password validation rules for basic authentication (e.g., password complexity: uppercase, lowercase, numbers, special characters, minimum length).
        builder.Services.AddIdentity<AspNetUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 15;
        })
        .AddErrorDescriber<DutchIdentityErrorDescriber>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        .AddPasswordValidator<ForbiddenPasswordValidator<AspNetUser>>();

        builder.Services.AddIdentityServer(options =>
        {
            // Note: This enables the automatic inclusion of the "aud" (audience) claim in access tokens.
            // This is recommended when validating tokens in APIs that expect an audience claim.
            options.EmitStaticAudienceClaim = true;
        })
        .AddProfileService<LocalUserProfileService>()
        .AddConfigurationStore(options =>
        {
            // Note: This DbContext manages all configuration-related data for IdentityServer: Clients, ApiResources, ApiScopes, IdentityResources.
            // These define what clients are allowed, what APIs exist, and what claims/scopes are available.
            options.ConfigureDbContext = optionsBuilder =>
                optionsBuilder.UseSqlServer(
                    builder.Configuration.GetConnectionString("IdentityServerDBConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly));
        })
        .AddConfigurationStoreCache()
        .AddOperationalStore(options =>
        {
            // Note: This DbContext stores operational data related to the runtime behavior of IdentityServer: PersistedGrants (authorization codes, refresh tokens, etc.), DeviceCodes (for device flow), and ServerSideSessions (for server-managed sessions).
            options.ConfigureDbContext = optionsBuilder =>
                optionsBuilder.UseSqlServer(
                    builder.Configuration.GetConnectionString("IdentityServerDBConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly));

            // Note: Enables automatic cleanup of expired tokens, codes, and sessions.
            options.EnableTokenCleanup = true;
        });
  

        ////////builder.Services.AddAuthentication()
        ////////    .AddOpenIdConnect("AAD", "Microsoft Entra ID", options =>
        ////////    {
        ////////        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        ////////        options.Authority = "https://login.microsoftonline.com/5692e72c-b118-45bb-8575-47c1c00b31ed/v2.0";
        ////////        options.ClientId = "3aebc331-5ebd-4e8b-ad95-5d3276bb5c22";
        ////////        options.ClientSecret = "ekP8Q~Umm.4AAyHUBzoPV.4vepJ2X6Foen2RAbjt";
        ////////        options.ResponseType = "code";
        ////////        options.CallbackPath = new PathString("/signin-aad/");
        ////////        options.SignedOutCallbackPath = new PathString("/signout-aad/");
        ////////        options.Scope.Add("email");
        ////////        options.Scope.Add("offline_access");
        ////////        options.SaveTokens = true;
        ////////    });

        builder.Services.AddAuthentication()
            .AddFacebook("Facebook", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.AppId = "784150890372035";
                options.AppSecret = "3f83916f987112cba3cfd4903b69b4a0";
            });

        // Note: ForwardedHeaders.XForwardedFor is a header that contains the ip-address, and ForwardedHeaders.XForwardedProto contains the original scheme.
        builder.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseForwardedHeaders();

        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment() || app.Environment.IsTest())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
