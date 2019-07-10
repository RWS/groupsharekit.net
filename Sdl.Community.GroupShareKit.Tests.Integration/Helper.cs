using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {
        public static Uri BaseUri => new Uri(Helper.GetVariable("GROUPSHAREKIT_BASEURI"));
        public static string TestOrganization => Helper.GetVariable("GROUPSHAREKIT_TESTORGANIZATION");

        public static string GetVariable(string key)
        {
            // by default it gets a process variable. Allow getting user as well
            return Environment.GetEnvironmentVariable(key) ??
                Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
        }

        public static async Task<IGroupShareClient> GetGroupShareClient()
        {
            var groupShareUser = Helper.GetVariable("GROUPSHAREKIT_USERNAME");
            var groupSharePassword = Helper.GetVariable("GROUPSHAREKIT_PASSWORD");
            var groupShareBearerId = Helper.GetVariable("GROUPSHAREKIT_BEARERID"); 

            var token = await GroupShareClient.GetRequestToken(
                groupShareUser,
                groupSharePassword,
                BaseUri,
                GroupShareClient.AllScopes);

            var gsClient = await GroupShareClient.AuthenticateClient(
                token,
                groupShareUser,
                groupSharePassword,
                groupShareBearerId,
                BaseUri,
                GroupShareClient.AllScopes);

            return gsClient;
        }
    }
}