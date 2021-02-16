using Sdl.Community.GroupShareKit.Clients;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class LogsClientTests
    {
        [Fact]
        public async Task AllLogs()
        {
            var groupShareClient = Helper.GsClient;
            var logsData = await groupShareClient.Logs.GetAllLogs();
            Assert.True(logsData.Count > 0);
        }
    }
}
