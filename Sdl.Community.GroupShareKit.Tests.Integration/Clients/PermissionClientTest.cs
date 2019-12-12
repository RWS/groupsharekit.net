//using System.Threading.Tasks;
//using Xunit;

//namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
//{
//    public class PermissionClientTest
//    {
//        [Fact]
//        public async Task GetAll()
//        {
//            var groupShareClient = await Helper.GetGroupShareClient();
//            var response = await groupShareClient.Permission.GetAll();

//            Assert.True(response.Count > 0);
//        }

//        [Fact]
//        public async Task GetAllPermissionsName()
//        {
//            var grClient = await Helper.GetGroupShareClient();
//            var response = await grClient.Permission.GetUsersPermisions();

//            Assert.True(response.Count > 0);
//        }
//    }
//}