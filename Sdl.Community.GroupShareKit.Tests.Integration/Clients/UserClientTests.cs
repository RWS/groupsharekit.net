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

            var response = await groupShareClient.User.GetAllUsers();

            Assert.True(response != null);
        }

        [Theory]
        [InlineData("test_api")]
        public async Task GetUser(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(response.Name.Equals(userName));
        }


        [Theory]
        [InlineData("test_chf")]
        public async Task Update(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            response.DisplayName = "Test";
            
            var user = await groupShareClient.User.Update(response);

            Assert.True(user != null);

            var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(userUpdated.DisplayName,"Test");

        }

        [Theory]
        [InlineData("test_")]
        public async Task Search(string text)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Search(text);

       
            Assert.True(response != null);

        }

        [Theory]
        [InlineData("test_api", "de-DE")]
        [InlineData("test_user","en-US")]
        public async Task UpdateUserLanguageDirections(string userName,string locale)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var expected = await groupShareClient.User.Get(new UserRequest(userName));

            expected.Locale = locale;
            await groupShareClient.User.Update(expected);

            var actual = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(expected.Locale.Equals(actual.Locale));
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var newUser = new CreateUserRequest
            {
                UniqueId = Guid.NewGuid(),
                Name = "testUser",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                Locale = "en-US",
                OrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
                UserType = "SDLUser",
                LanguageDirections = new List<LanguageDirections>
                {
                    new LanguageDirections
                    {
                        Id = 1,
                        SourceLanguageCode = "en-Us",
                        TargetLanguageCode = "fr-FR"
                    }
                }
            };

            var userId = await groupShareClient.User.Create(newUser);

            Assert.True(userId != null);

            await groupShareClient.User.Delete(userId);
        }
    }
}
