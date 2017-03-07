using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.True(response.Count>0);
        }

        [Theory]
        [InlineData("793f3f38-3899-49e5-b793-99a53cd1d24d")]
        public async Task GetRole(string roleId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();


            var response = await groupShareClient.Role.GetRole(roleId);

            Assert.Equal(response.UniqueId.ToString(),roleId);
        }



        //[Fact]
        //public async Task RoleMembership()
        //{
        //    var groupShareClient = await Helper.GetAuthenticatedClient();

        //    var newRoleMembership = new List<Role>
        //    {
        //        new Role
        //        {
        //            OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //            UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
        //            RoleId = new Guid("ba6f1a20-eb88-44d0-87d6-521613468941")
        //        },

        //        new Role
        //        {
        //            OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //            UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
        //            RoleId = new Guid("3e355ecd-bd14-41d8-82f1-03923e19ff38")
        //        }
        //    };

        //    await groupShareClient.Role.RoleMembership(newRoleMembership);

        //    var roleMembershipToRemove = new List<Role>
        //    {
        //        new Role
        //        {
        //            OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //            UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
        //            RoleId = new Guid("ba6f1a20-eb88-44d0-87d6-521613468941")
        //        }
        //    };

        //    await groupShareClient.Role.DeleteRoleMembership(roleMembershipToRemove);
        //}


        [Fact]
        public async Task CreateRole()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var roleId =
                await
                    groupShareClient.Role.CreateRole(new RoleRequest(Guid.NewGuid(),
                        "testRole", false, new List<Permission>() {new Permission()
                        {
                            UniqueId = new Guid("b05db681-2871-4cb4-9789-61a5e9d0cfb4"),
                            DisplayName = "View Library",
                            Description = null,
                            FullName = "RG.view",
                            PermissionName = "view",
                            ResourceName = "RG"
                        } }));

            Assert.True(roleId!=string.Empty);

            await groupShareClient.Role.DeleteRole(roleId);
        }

        [Theory]
        [InlineData("793f3f38-3899-49e5-b793-99a53cd1d24d")]
        public async Task GetUsersForSpecificRole(string roleId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var users = await groupShareClient.Role.GetUsersForRole(roleId);

            Assert.True(users.Count!=0);
        }

        [Theory]
        [InlineData("b05db681-2871-4cb4-9789-61a5e9d0cfb4")]
        public async Task AddUsersToRole(string roleId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var roleList = new List<Role>
            {
                new Role
                {
                    OrganizationId = "ee72759d-917e-4c60-ba30-1ed595699c4d",
                    UserId = "6d4e85a2-163b-4574-8c56-60d96e2296f3",
                    RoleId = roleId
                }
            };
            await groupShareClient.Role.AddUserToRole(roleList);

            var roles = await groupShareClient.Role.GetUsersForRole(roleId);

            var addedUser = roles.FirstOrDefault(u => u.UniqueId.ToString() == "6d4e85a2-163b-4574-8c56-60d96e2296f3");

            Assert.True(addedUser!=null);
        }

        [Theory]
        [InlineData("b05db681-2871-4cb4-9789-61a5e9d0cfb4")]
        public async Task RemoveUsersFromRole(string roleId)
        {

            var groupShareClient = await Helper.GetAuthenticatedClient();
            var roleList = new List<Role>
            {
                new Role
                {
                    OrganizationId = "ee72759d-917e-4c60-ba30-1ed595699c4d",
                    UserId = "6d4e85a2-163b-4574-8c56-60d96e2296f3",
                    RoleId = roleId
                }
            };

            await groupShareClient.Role.RemoveUserFromRole(roleList, roleId);
            var roles = await groupShareClient.Role.GetUsersForRole(roleId);

            var addedUser = roles.FirstOrDefault(u => u.UniqueId.ToString() == "6d4e85a2-163b-4574-8c56-60d96e2296f3");

            Assert.True(addedUser == null);
        }


    }
}
