using AutoMapper;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace QuizTower.IDP
{
    public class SeedDataWebHookBased
    {
        public static void EnsureSeedData(ConfigurationDbContext context, IConfiguration configuration, IWebHostEnvironment env, IMapper mapper, ILogger<SeedDataWebHookBased> logger)
        {
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
                            .Include(c => c.PostLogoutRedirectUris)
                            .Include(c => c.AllowedCorsOrigins)
                            .Include(c => c.ClientSecrets)
                            .FirstOrDefault(c => c.ClientId == client.ClientId);

                        if (existingClient == null)
                        {
                            logger.LogDebug($"Adding new client: {client.ClientId}");
                            context.Clients.Add(client.ToEntity());
                        }
                        else
                        {
                            logger.LogDebug($"Updating existing client: {client.ClientId}");
                            var clientEntity = client.ToEntity();
                            mapper.Map(clientEntity, existingClient);

                            // Update Redirect URIs
                            UpdateClientRedirectUris(context, existingClient, clientEntity);

                            // Update PostLogoutRedirectUris
                            UpdateClientPostLogoutRedirectUris(context, existingClient, clientEntity);

                            // Update FrontChannelLogoutUri
                            UpdateClientFrontChannelLogoutUri(existingClient, clientEntity);

                            // Update BackChannelLogoutUri
                            UpdateClientBackChannelLogoutUri(existingClient, clientEntity);

                            // Update AllowedCorsOrigins
                            UpdateClientCorsOrigins(context, existingClient, clientEntity);
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
                            logger.LogDebug($"Adding new identity resource: {resource.Name}");
                            context.IdentityResources.Add(resource.ToEntity());
                        }
                        else
                        {
                            logger.LogDebug($"Updating existing identity resource: {resource.Name}");
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
                            logger.LogDebug($"Adding new API scope: {scope.Name}");
                            context.ApiScopes.Add(scope.ToEntity());
                        }
                        else
                        {
                            logger.LogDebug($"Updating existing API scope: {scope.Name}");
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
                            logger.LogDebug($"Adding new API resource: {resource.Name}");
                            context.ApiResources.Add(resource.ToEntity());
                        }
                        else
                        {
                            logger.LogDebug($"Updating existing API resource: {resource.Name}");
                            mapper.Map(resource.ToEntity(), existingResource);
                        }
                    }
                    context.SaveChanges();

                    transaction.Commit();
                    logger.LogInformation("Seed data transaction committed successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while seeding the database, rolling back transaction.");
                    transaction.Rollback();
                }
            }
        }

        private static void UpdateClientRedirectUris(ConfigurationDbContext context, Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            foreach (var oldUri in existingClient.RedirectUris.ToList())
            {
                if (clientEntity.RedirectUris.All(r => r.RedirectUri != oldUri.RedirectUri))
                {
                    context.Remove(oldUri);
                }
            }

            foreach (var newUri in clientEntity.RedirectUris)
            {
                if (existingClient.RedirectUris.All(r => r.RedirectUri != newUri.RedirectUri))
                {
                    existingClient.RedirectUris.Add(new Duende.IdentityServer.EntityFramework.Entities.ClientRedirectUri
                    {
                        RedirectUri = newUri.RedirectUri,
                        ClientId = existingClient.Id
                    });
                }
            }
        }

        private static void UpdateClientPostLogoutRedirectUris(ConfigurationDbContext context, Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            foreach (var oldUri in existingClient.PostLogoutRedirectUris.ToList())
            {
                if (clientEntity.PostLogoutRedirectUris.All(r => r.PostLogoutRedirectUri != oldUri.PostLogoutRedirectUri))
                {
                    context.Remove(oldUri);
                }
            }

            foreach (var newUri in clientEntity.PostLogoutRedirectUris)
            {
                if (existingClient.PostLogoutRedirectUris.All(r => r.PostLogoutRedirectUri != newUri.PostLogoutRedirectUri))
                {
                    existingClient.PostLogoutRedirectUris.Add(new Duende.IdentityServer.EntityFramework.Entities.ClientPostLogoutRedirectUri
                    {
                        PostLogoutRedirectUri = newUri.PostLogoutRedirectUri,
                        ClientId = existingClient.Id
                    });
                }
            }
        }

        private static void UpdateClientFrontChannelLogoutUri(Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            if (existingClient.FrontChannelLogoutUri != clientEntity.FrontChannelLogoutUri)
            {
                existingClient.FrontChannelLogoutUri = clientEntity.FrontChannelLogoutUri;
            }
        }

        private static void UpdateClientBackChannelLogoutUri(Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            if (existingClient.BackChannelLogoutUri != clientEntity.BackChannelLogoutUri)
            {
                existingClient.BackChannelLogoutUri = clientEntity.BackChannelLogoutUri;
            }
        }

        private static void UpdateClientCorsOrigins(ConfigurationDbContext context, Duende.IdentityServer.EntityFramework.Entities.Client existingClient, Duende.IdentityServer.EntityFramework.Entities.Client clientEntity)
        {
            foreach (var oldOrigin in existingClient.AllowedCorsOrigins.ToList())
            {
                if (clientEntity.AllowedCorsOrigins.All(r => r.Origin != oldOrigin.Origin))
                {
                    context.Remove(oldOrigin);
                }
            }

            foreach (var newOrigin in clientEntity.AllowedCorsOrigins)
            {
                if (existingClient.AllowedCorsOrigins.All(r => r.Origin != newOrigin.Origin))
                {
                    existingClient.AllowedCorsOrigins.Add(new Duende.IdentityServer.EntityFramework.Entities.ClientCorsOrigin
                    {
                        Origin = newOrigin.Origin,
                        ClientId = existingClient.Id
                    });
                }
            }
        }
    }
}
