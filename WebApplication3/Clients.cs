using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace WebApplication3
{
    public class Clients
    {
        public static IEnumerable<Client> getClients =>
            new List<Client>
            {
                        // machine to machine client
                        new Client
                        {
                            ClientId = "client",
                            ClientSecrets = { new Secret("secret".Sha256()) },

                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            // scopes that client has access to
                            AllowedScopes = { "api1" }
                        },
                
                        // interactive ASP.NET Core MVC client
                        new Client
                        {
                            ClientId = "mvc",
                            ClientSecrets = { new Secret("secret".Sha256()) },

                            AllowedGrantTypes = GrantTypes.Code,
                    
                            // where to redirect to after login
                            RedirectUris = { "https://localhost:5002/signin-oidc" },

                            // where to redirect to after logout
                            PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                            AllowOfflineAccess = true,

                            AllowedScopes = new List<string>
                            {
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                "api1"
                            }
                        }
            };
    }
}
