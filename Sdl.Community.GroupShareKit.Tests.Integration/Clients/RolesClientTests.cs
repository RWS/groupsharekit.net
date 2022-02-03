using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class RolesClientTests
    {
        [Fact]
        public async Task GetAllRoles()
        {
            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.Role.GetAllRoles();

            Assert.True(response.Count > 0);
        }

        [Theory]
        [MemberData(nameof(UserData.UserRole), MemberType = typeof(UserData))]
        public async Task GetRole(string roleId)
        {
            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.Role.GetRole(roleId);

            Assert.Equal(response.UniqueId.ToString(), roleId);
        }

        //[Fact]
        //public async Task RoleMembership()
        //{
        //    var groupShareClient = Helper.GsClient;

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
            var groupShareClient = Helper.GsClient;
            var id = Guid.NewGuid();
            var name = $"testRole-{id}";
            var permissions = await groupShareClient.Permission.GetAll();
            var roleId = await groupShareClient.Role.CreateRole(new RoleRequest(
                        id,
                        name,
                        false,
                        new List<Permission>() {new Permission()
                        {
                            UniqueId = permissions.First().UniqueId,
                            DisplayName = permissions.First().DisplayName,
                            Description = null,
                            FullName = permissions.First().FullName,
                            PermissionName =permissions.First().PermissionName,
                            ResourceName = permissions.First().ResourceName
                        } }));

            Assert.True(roleId != string.Empty);
        }

        [Theory]
        [MemberData(nameof(UserData.UserId), MemberType = typeof(UserData))]
        public async Task AddRemoveUsersToRole(string userId)
        {
            var groupShareClient = Helper.GsClient;
            var id = Guid.NewGuid();
            var name = $"testRole-{id}";
            var permissions = await groupShareClient.Permission.GetAll();
            var roleId = await groupShareClient.Role.CreateRole(new RoleRequest(
                       id,
                       name,
                       false,
                      new List<Permission>() {new Permission()
                        {
                            UniqueId = permissions.First().UniqueId,
                            DisplayName = permissions.First().DisplayName,
                            Description = null,
                            FullName = permissions.First().FullName,
                            PermissionName =permissions.First().PermissionName,
                            ResourceName = permissions.First().ResourceName
                        } }));
            var roleList = new List<Role>
            {
                new Role
                {
                    OrganizationId = Helper.OrganizationId,
                    UserId = userId,
                    RoleId = roleId
                }
            };
            await groupShareClient.Role.AddUserToRole(roleList);

            var roles = await groupShareClient.Role.GetUsersForRole(roleId);

            var addedRole = roles.FirstOrDefault(u => u.UniqueId.ToString() == userId);

            Assert.True(addedRole != null);

            await groupShareClient.Role.RemoveUserFromRole(roleList, roleId);

            roles = await groupShareClient.Role.GetUsersForRole(roleId);

            var removedRole = roles.FirstOrDefault(u => u.UniqueId.ToString() == userId);

            Assert.True(removedRole == null);

            await groupShareClient.Role.DeleteRole(roleId);
        }


        [Theory]
        [MemberData(nameof(UserData.UserRole), MemberType = typeof(UserData))]
        public async Task GetUsersForSpecificRole(string roleId)
        {
            var groupShareClient = Helper.GsClient;
            var userId = await CreatePowerUser(groupShareClient);

            
            var users = await groupShareClient.Role.GetUsersForRole(roleId);


            Assert.True(users.Count != 0);


            await groupShareClient.User.Delete(userId);
        }

        private static async Task<String> CreatePowerUser(GroupShareClient groupShareClient)
        {
            var uniqueId = Guid.NewGuid().ToString();

            var newUser = new CreateUserRequest
            {
                Name = $"automated user {uniqueId}",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                Locale = "en-US",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<Role>
                {
                    new Role
                    {
                         OrganizationId = Helper.OrganizationId,
                         RoleId = Helper.PowerUserRoleId,
                         UserId = uniqueId
                    }
                }
            };

            return await groupShareClient.User.Create(newUser);
        }
    }
}