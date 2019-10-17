using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public static class Helper
    {
        public static GroupShareClient GsClient { get; }

        public static Uri BaseUri => new Uri(GetVariable("GROUPSHAREKIT_BASEURI"));

        public static string GsUser => GetVariable("GROUPSHAREKIT_USERNAME");

        public static Guid GsUserId { get; }

        public static string GsPassword => GetVariable("GROUPSHAREKIT_PASSWORD");

        public static string GsBearerId = GetVariable("GROUPSHAREKIT_BEARERID");

        public static string Organization => GetVariable("GROUPSHAREKIT_TESTORGANIZATION");

        public static string OrganizationId { get; }

        public static string OrganizationTag { get; }

        public static string PowerUserRoleId { get; }

        static Helper()
        {
            var token = GroupShareClient.GetRequestToken(
                GsUser,
                GsPassword,
                BaseUri,
                GroupShareClient.AllScopes).Result;

            GsClient = GroupShareClient.AuthenticateClient(
                token,
                GsUser,
                GsPassword,
                GsBearerId,
                BaseUri,
                GroupShareClient.AllScopes).Result;

            GsUserId = GsClient.User.Get(new UserRequest(GsUser)).Result.UniqueId;

            var organization = GsClient.Organization.GetAll(new OrganizationRequest(true)).Result.FirstOrDefault(o => o.Name == Organization);
            if (organization != null) OrganizationId = organization.UniqueId.ToString();
            if (organization != null) OrganizationTag = organization.Tags.FirstOrDefault();
            var role = GsClient.Role.GetAllRoles().Result.FirstOrDefault(r => r.Name == "Power User");
            if (role != null) PowerUserRoleId = role.UniqueId.ToString();
        }

        private static GroupShareClient gsClient;
        public static async Task<IGroupShareClient> GetGroupShareClient()
        {
            if (gsClient != null)
            { return gsClient; }

            var token = await GroupShareClient.GetRequestToken(
                GsUser,
                GsPassword,
                BaseUri,
                GroupShareClient.AllScopes);

            gsClient = await GroupShareClient.AuthenticateClient(
                token,
                GsUser,
                GsPassword,
                "",
                BaseUri,
                GroupShareClient.AllScopes);

            return gsClient;
        }

        public static string GetVariable(string key)
        {
            // by default it gets a process variable. Allow getting user as well
            return
                Environment.GetEnvironmentVariable(key) ??
                Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
        }

        public static async Task<string> CreateOrganizationAsync()
        {
            var uniqueId = Guid.NewGuid();
            var organization = new Organization()
            {
                UniqueId = uniqueId,
                Name = $"automated organization {uniqueId}",
                IsLibrary = false,
                Description = null,
                Path = null,
                ParentOrganizationId = new Guid(OrganizationId),
                ChildOrganizations = null
            };

            return await gsClient.Organization.Create(organization);
        }

        public static async Task<string> CreateTemplateResourceAsync(string orgId)
        {
            var id = Guid.NewGuid().ToString();
            var templateRequest = new ProjectTemplates(id, $"automated template {id}", "", orgId);
            var rawData = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));
            var templateId = await gsClient.Project.CreateTemplate(templateRequest, rawData);
            return templateId;
        }
    }
}