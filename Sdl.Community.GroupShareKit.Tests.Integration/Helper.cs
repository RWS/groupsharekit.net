using System;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {

        private static readonly Lazy<Credentials> CredentialsThunk = new Lazy<Credentials>(() =>
        {
            var groupShareUser = Environment.GetEnvironmentVariable("GROUPSHAREKIT_USERNAME");
            var groupSharePassword = Environment.GetEnvironmentVariable("GROUPSHAREKIT_PASSWORD");

            return new Credentials(groupShareUser,groupSharePassword);
        });

        public static Credentials Credentials => CredentialsThunk.Value;


        public static async Task<GroupShareClient> GetAuthenticatedClient()
        {
            return await GroupShareClient.AuthenticateClient(Credentials.Login, Credentials.Password,
               BaseUri,
               GroupShareClient.AllScopes);
        }

        public static Uri BaseUri => new Uri(Environment.GetEnvironmentVariable("GROUPSHAREKIT_BASEURI"));

        public static string TestOrganization => Environment.GetEnvironmentVariable("GROUPSHAREKIT_TESTORGANIZATION");
    }
}
