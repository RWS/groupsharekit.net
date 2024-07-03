using Sdl.Community.GroupShareKit.Clients;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PermissionClientTest
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetAll()
        {
            var response = await GroupShareClient.Permission.GetAll();

            Assert.True(response.Count > 0);
        }

        [Fact]
        public async Task GetAllPermissionsNames()
        {
            var response = await GroupShareClient.Permission.GetUsersPermissions();

            Assert.True(response.Count > 0);
        }

        [Fact]
        public async Task GetUserPermissions_hideImplicitLibs_false()
        {
            var userRequest = new UsersRequest(1, 2, 7);
            var users = await GroupShareClient.User.GetAllUsers(userRequest);
            var currentUser = users.Items.First(user => user.Name == Helper.GsUser);

            var templateId = await Helper.CreateTemplateResourceAsync(Guid.Parse(Helper.OrganizationId));
            var projectId = await Helper.CreateProjectAsync(templateId);

            var organizationPermissions = await GroupShareClient.Permission.GetUserPermissions(currentUser.Name, hideImplicitLibs: false);
            var firstOrganizationPermissions = organizationPermissions.First();
            Assert.True(firstOrganizationPermissions.Permissions.Count > 0);
            Assert.True(firstOrganizationPermissions.Permissions.Any());

            var projectResourcesPermissions = firstOrganizationPermissions.ChildOrganizations.First(o => o.Name == "Project Resources");
            Assert.Contains(projectResourcesPermissions.ChildOrganizations, o => o.Name == "Project");
            Assert.Equal(projectResourcesPermissions.Permissions.Count, firstOrganizationPermissions.Permissions.Count);

            await Helper.DeleteProjectAsync(projectId);
            await Helper.DeleteProjectTemplateAsync(templateId);
        }

        [Fact]
        public async Task GetUserPermissions_hideImplicitLibs_true()
        {
            var userRequest = new UsersRequest(1, 2, 7);
            var users = await GroupShareClient.User.GetAllUsers(userRequest);
            var currentUser = users.Items.First(user => user.Name == Helper.GsUser);

            var templateId = await Helper.CreateTemplateResourceAsync(Guid.Parse(Helper.OrganizationId));
            var projectId = await Helper.CreateProjectAsync(templateId);

            var organizationPermissions = await GroupShareClient.Permission.GetUserPermissions(currentUser.Name, hideImplicitLibs: true);
            Assert.True(organizationPermissions.Count > 0);

            var firstOrganizationPermissions = organizationPermissions.First();
            Assert.True(firstOrganizationPermissions.Permissions.Any());
            Assert.True(firstOrganizationPermissions.ChildOrganizations.All(o => o.Name != "Project Resources"));

            await Helper.DeleteProjectAsync(projectId);
            await Helper.DeleteProjectTemplateAsync(templateId);
        }

    }
}