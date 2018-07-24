
using System;
using System.Configuration;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {

        private static string GetVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? ConfigurationManager.AppSettings[key];
        }

        public static async Task<GroupShareClient> GetGroupShareClient()
        {
            var groupShareUser = Helper.GetVariable("GROUPSHAREKIT_USERNAME");
            var groupSharePassword = Helper.GetVariable("GROUPSHAREKIT_PASSWORD");

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


        public static Uri BaseUri => new Uri(Helper.GetVariable("GROUPSHAREKIT_BASEURI"));

        public static string TestOrganization => Helper.GetVariable("GROUPSHAREKIT_TESTORGANIZATION");
    }
}
