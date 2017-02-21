using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Fact]
        public async Task GetAllUsers()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var userRequest = new UsersRequest(1,2,7);

            var users = await groupShareClient.User.GetAllUsers(userRequest);

            Assert.True(users.Count>0);
        }

        [Theory]
        [InlineData("rcrisan")]
        public async Task GetUser(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(response.Name.Equals(userName));
        }

        [Theory]
        [InlineData("83551d37-2568-4bc6-9342-2fce68ed6b0a")]
        public async Task GetUserById(string userId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var user = await groupShareClient.User.GetUserById(userId);

            Assert.Equal(user.UniqueId.ToString(),userId);
        }

        [Theory]
        [InlineData("aghisa")]
        public async Task Update(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            response.Description = "Description";

            var user = await groupShareClient.User.Update(response);

            Assert.True(user != string.Empty);

            var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(userUpdated.Description, "Description");

        }

        //[Theory]
        //[InlineData("test_api", "de-DE")]
        //[InlineData("test_user","en-US")]
        //public async Task UpdateUserLanguageDirections(string userName,string locale)
        //{
        //    var groupShareClient = await Helper.GetAuthenticatedClient();
        //    var expected = await groupShareClient.User.Get(new UserRequest(userName));

        //    expected.Locale = locale;
        //    await groupShareClient.User.Update(expected);

        //    var actual = await groupShareClient.User.Get(new UserRequest(userName));

        //    Assert.True(expected.Locale.Equals(actual.Locale));
        //}

        //[Fact]
        //public async Task Create()
        //{
        //    var groupShareClient = await Helper.GetAuthenticatedClient();
        //    var uniqueId = Guid.NewGuid();

        //    var newUser = new CreateUserRequest
        //    {
        //        UniqueId = uniqueId,
        //        Name = "testUser",
        //        Password = "Password1",
        //        DisplayName = "test",
        //        Description = null,
        //        PhoneNumber = null,
        //        Locale = "en-US",
        //        OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //        UserType = "SDLUser",
        //        Roles = new List<Role>
        //        {
        //            new Role
        //            {
        //                 OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
        //                  RoleId = new Guid("0340ad05-63d2-4db6-8bbd-696fac125a19"),//power user
        //                   UserId = uniqueId
        //            }
        //        }
        //    };

        //    var userId = await groupShareClient.User.Create(newUser);

        //    Assert.True(userId != null);

        //    await groupShareClient.User.Delete(userId);
        //}
    }
}
