using System;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {

        public static async Task<GroupShareClient> GetGroupShareClient()
        {
            var groupShareUser = Environment.GetEnvironmentVariable("GROUPSHAREKIT_USERNAME");
            var groupSharePassword = Environment.GetEnvironmentVariable("GROUPSHAREKIT_PASSWORD");

            var token =
                await
                    GroupShareClient.GetRequestToken(groupShareUser, groupSharePassword, BaseUri,
                        GroupShareClient.AllScopes);
            var gsClient =
                await
                    GroupShareClient.AuthenticateClient(token, groupShareUser, groupSharePassword,BaseUri,
                        GroupShareClient.AllScopes);
            return gsClient;

        } 


        public static Uri BaseUri => new Uri(Environment.GetEnvironmentVariable("GROUPSHAREKIT_BASEURI"));

        public static string TestOrganization => Environment.GetEnvironmentVariable("GROUPSHAREKIT_TESTORGANIZATION");
    }
}
