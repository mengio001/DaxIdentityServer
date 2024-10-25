using AutoMapper;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using static System.Formats.Asn1.AsnWriter;

namespace QuizTower.IDP
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                EnsureSeedData(context, configuration, env, mapper);
            }
        }

        private static void EnsureSeedData(ConfigurationDbContext context, IConfiguration? configuration, IWebHostEnvironment env, IMapper mapper)
        { 

            // Using a transaction to ensure consistency during the seeding process
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Seed Clients
                    var configClients = Config.Clients(configuration, env).ToList();
                    foreach (var client in configClients)
                    {
                        var existingClient = context.Clients
                            .Include(c => c.RedirectUris)
                            .FirstOrDefault(c => c.ClientId == client.ClientId);

                        if (existingClient == null)
                        {
                            Log.Debug($"Adding new client: {client.ClientId}");
                            context.Clients.Add(client.ToEntity());
                        }
                        else
                        {
                            Log.Debug($"Updating existing client: {client.ClientId}");
                            var clientEntity = client.ToEntity();
                            mapper.Map(clientEntity, existingClient);

                            // Update Redirect URIs
                            UpdateClientRedirectUris(context, existingClient, clientEntity);
                        }
                    }
                    context.SaveChanges();

                    // Seed Identity Resources
                    var configIdentityResources = Config.IdentityResources.ToList();
                    foreach (var resource in configIdentityResources)
                    {
                        var existingResource = context.IdentityResources.FirstOrDefault(r => r.Name == resource.Name);
                        if (existingResource == null)
                        {
                            Log.Debug($"Adding new identity resource: {resource.Name}");
                            context.IdentityResources.Add(resource.ToEntity());
                        }
                        else
                        {
                            Log.Debug($"Updating existing identity resource: {resource.Name}");
                            mapper.Map(resource.ToEntity(), existingResource);
                        }
                    }
                    context.SaveChanges();

                    // Seed API Scopes
                    var configApiScopes = Config.ApiScopes.ToList();
                    foreach (var scope in configApiScopes)
                    {
                        var existingScope = context.ApiScopes.FirstOrDefault(s => s.Name == scope.Name);
                        if (existingScope == null)
                        {
                            Log.Debug($"Adding new API scope: {scope.Name}");
                            context.ApiScopes.Add(scope.ToEntity());
                        }
                        else
                        {
                            Log.Debug($"Updating existing API scope: {scope.Name}");
                            mapper.Map(scope.ToEntity(), existingScope);
                        }
                    }
                    context.SaveChanges();

                    // Seed API Resources
                    var configApiResources = Config.ApiResources.ToList();
                    foreach (var resource in configApiResources)
                    {
                        var existingResource = context.ApiResources.FirstOrDefault(r => r.Name == resource.Name);
                        if (existingResource == null)
                        {
                            Log.Debug($"Adding new API resource: {resource.Name}");
                            context.ApiResources.Add(resource.ToEntity());
                        }
                        else
                        {
                            Log.Debug($"Updating existing API resource: {resource.Name}");
                            mapper.Map(resource.ToEntity(), existingResource);
                        }
                    }
                    context.SaveChanges();

                    // Commit the transaction after successful seeding
                    transaction.Commit();
                    Log.Information("Seed data transaction committed successfully.");
                }
                catch (Exception ex)
                {
                    // If anything goes wrong, roll back the transaction
                    Log.Fatal(ex, "Error occurred while seeding the database, rolling back transaction.");
                    transaction.Rollback();
                }
            }
        }

        private static void UpdateClientRedirectUris(ConfigurationDbContext context, Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            // Remove old URIs that are not in the new client
            foreach (var oldUri in existingClient.RedirectUris.ToList())
            {
                if (clientEntity.RedirectUris.All(r => r.RedirectUri != oldUri.RedirectUri))
                {
                    context.Remove(oldUri);
                }
            }

            // Add new URIs that are not in the existing client
            foreach (var newUri in clientEntity.RedirectUris)
            {
                if (existingClient.RedirectUris.All(r => r.RedirectUri != newUri.RedirectUri))
                {
                    existingClient.RedirectUris.Add(new ClientRedirectUri
                    {
                        RedirectUri = newUri.RedirectUri,
                        ClientId = existingClient.Id
                    });
                }
            }
        }
    }
}
