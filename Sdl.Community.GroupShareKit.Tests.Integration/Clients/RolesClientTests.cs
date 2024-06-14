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
            var roles = await groupShareClient.Role.GetRoles();

            Assert.True(roles.Count > 0);
        }

        [Theory]
        [MemberData(nameof(UserData.UserRole), MemberType = typeof(UserData))]
        public async Task GetRole(Guid roleId)
        {
            var groupShareClient = Helper.GsClient;
            var role = await groupShareClient.Role.GetRole(roleId);

            Assert.Equal(roleId, role.UniqueId);
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
        //        {
        //            new Role
        //            {
        //                OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //                UserId = new Guid("36c91548-8b79-4ba1-a252-cea654184230"),
        //                RoleId = new Guid("ba6f1a20-eb88-44d0-87d6-521613468941")
        //            }
        //        };

        //    await groupShareClient.Role.DeleteRoleMembership(roleMembershipToRemove);
        //}

        [Fact]
        public async Task CreateRole()
        {
            var groupShareClient = Helper.GsClient;

            var roleName = $"Test role-{Guid.NewGuid()}";

            var role = new Role
            {
                Name = roleName,
                Permissions = new List<Permission>(),
                IsProtected = false
            };

            var roleId = await groupShareClient.Role.CreateRole(role);
            var retrievedRole = await groupShareClient.Role.GetRole(roleId);

            Assert.Equal(roleName, retrievedRole.Name);
        }

        [Fact]
        public async Task AddRemoveUsersToRole()
        {
            var groupShareClient = Helper.GsClient;
            var roleName = $"Test role-{Guid.NewGuid()}";
            var permissions = await groupShareClient.Permission.GetAll();
            var permission = permissions.First();

            var role = new Role
            {
                Name = roleName,
                Permissions = new List<Permission> { permission },
                IsProtected = false
            };

            var roleId = await groupShareClient.Role.CreateRole(role);

            var newUser = new CreateUserRequest
            {
                Name = $"TestUser-{Guid.NewGuid()}",
                Password = "Password1",
                DisplayName = "Test User",
                Description = "Created using GroupShare Kit",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId)
                    }
                }
            };

            var userId = await groupShareClient.User.Create(newUser);

            var roleList = new List<RoleMembership>
            {
                new RoleMembership
                {
                    OrganizationId = Guid.Parse(Helper.OrganizationId),
                    RoleId = roleId,
                    UserId = Guid.Parse(userId),
                }
            };

            await groupShareClient.Role.AddUserToRole(roleList);

            var usersWithSpecificRole = await groupShareClient.Role.GetUsersForRole(roleId.ToString());

            var userWithSpecificRole = usersWithSpecificRole.FirstOrDefault(u => u.UniqueId.ToString() == userId);

            Assert.NotNull(userWithSpecificRole);

            await groupShareClient.Role.RemoveUserFromRole(roleList);

            usersWithSpecificRole = await groupShareClient.Role.GetUsersForRole(roleId.ToString());

            userWithSpecificRole = usersWithSpecificRole.FirstOrDefault(u => u.UniqueId.ToString() == userId);

            Assert.Null(userWithSpecificRole);

            await groupShareClient.Role.DeleteRole(roleId.ToString());
            await groupShareClient.User.Delete(userId);
        }

        [Theory]
        [MemberData(nameof(UserData.UserRole), MemberType = typeof(UserData))]
        public async Task GetUsersForSpecificRole(string roleId)
        {
            var groupShareClient = Helper.GsClient;
            var userId = await CreatePowerUser(groupShareClient);

            var users = await groupShareClient.Role.GetUsersForRole(roleId);

            Assert.NotEmpty(users);

            await groupShareClient.User.Delete(userId);
        }

        private static async Task<string> CreatePowerUser(GroupShareClient groupShareClient)
        {
            var uniqueId = Guid.NewGuid().ToString();

            var newUser = new CreateUserRequest
            {
                Name = $"automated user {uniqueId}",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = Guid.Parse(uniqueId)
                    }
                }
            };

            return await groupShareClient.User.Create(newUser);
        }
    }
}
