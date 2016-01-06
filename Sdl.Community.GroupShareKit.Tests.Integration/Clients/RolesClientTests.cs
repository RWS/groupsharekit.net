using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class RolesClientTests
    {
        [Fact]
        public async Task GetAllRoles()
        {

            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.Role.GetAllRoles();

            Assert.True(response != null);
        }

        [Theory]
        [InlineData("3e355ecd-bd14-41d8-82f1-03923e19ff38")]
        public async Task GetRole(string roleId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();


            var response = await groupShareClient.Role.GetRole(roleId);

            Assert.True(response != null);
        }



        [Fact]
        public async Task RoleMembership()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var newRoleMembership = new List<Role>
            {
                new Role
                {
                    OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
                    UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
                    RoleId = new Guid("ba6f1a20-eb88-44d0-87d6-521613468941")
                },

                new Role
                {
                    OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
                    UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
                    RoleId = new Guid("3e355ecd-bd14-41d8-82f1-03923e19ff38")
                }
            };

            await groupShareClient.Role.RoleMembership(newRoleMembership);

            var roleMembershipToRemove = new List<Role>
            {
                new Role
                {
                    OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
                    UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
                    RoleId = new Guid("ba6f1a20-eb88-44d0-87d6-521613468941")
                }
            };

            await groupShareClient.Role.DeleteRoleMembership(roleMembershipToRemove);
        }


        [Fact]
        public async Task CreateRole()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var roleId =
                await
                    groupShareClient.Role.CreateRole(new RoleRequest(Guid.NewGuid(),
                        "test", false, new List<Permission>() {new Permission()
                        {
                            UniqueId = new Guid("7801e614-5ff6-45cb-8c1e-30b6068c9579"),
                            DisplayName = "View Library",
                            Description = null,
                            FullName = "RG.view",
                            PermissionName = "view",
                            ResourceName = "RG"
                        } }));

             Assert.True(roleId != null);

            await groupShareClient.Role.DeleteRole(roleId);
        }

        [Theory]
        [InlineData("0340ad05-63d2-4db6-8bbd-696fac125a19")]
        public async Task UpdateRole(string roleId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var role = await groupShareClient.Role.GetRole(roleId);
            role.Name = "test";
            await groupShareClient.Role.Update(role);

            var updatedRole = await groupShareClient.Role.GetRole(roleId);
            Assert.Equal(updatedRole.Name, "test");

            //change role name back to power user
            var roleUpdated = await groupShareClient.Role.GetRole(roleId);
            roleUpdated.Name = "Power User";
            await groupShareClient.Role.Update(roleUpdated);

            var updatedRollName = await groupShareClient.Role.GetRole(roleId);
            Assert.Equal(updatedRollName.Name, "Power User");


        }

    }
}
