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

            var userId = await groupShareClient.User.CreateUser(newUser);

            var roleList = new List<RoleMembership>
            {
                new RoleMembership
                {
                    OrganizationId = Guid.Parse(Helper.OrganizationId),
                    RoleId = roleId,
                    UserId = userId,
                }
            };

            await groupShareClient.Role.AddUserToRole(roleList);

            var usersWithSpecificRole = await groupShareClient.Role.GetUsersForRole(roleId);

            var userWithSpecificRole = usersWithSpecificRole.FirstOrDefault(u => u.UniqueId == userId);

            Assert.NotNull(userWithSpecificRole);

            await groupShareClient.Role.RemoveUserFromRole(roleList);

            usersWithSpecificRole = await groupShareClient.Role.GetUsersForRole(roleId);

            userWithSpecificRole = usersWithSpecificRole.FirstOrDefault(u => u.UniqueId == userId);

            Assert.Null(userWithSpecificRole);

            await groupShareClient.Role.DeleteRole(roleId);
            await groupShareClient.User.DeleteUser(userId);
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
            var uniqueId = Guid.NewGuid();
            var name = $"User - {uniqueId}";

            var newUser = new CreateUserRequest
            {
                Name = name,
                Password = "Password1",
                DisplayName = name,
                Description = "Created using GroupShare Kit",
                PhoneNumber = null,
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = uniqueId
                    }
                }
            };

            return await groupShareClient.User.Create(newUser);
        }
    }
}
