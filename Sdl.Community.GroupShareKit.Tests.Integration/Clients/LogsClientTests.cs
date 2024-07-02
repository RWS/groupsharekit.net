using Sdl.Community.GroupShareKit.Clients.Logging;
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

        [Fact]
        public async Task FilteredLogs()
        {
            var groupShareClient = Helper.GsClient;
            var filter = new LogsFilter
            {
                FromDate = DateTime.Now.AddDays(-15),
                ToDate = DateTime.Now,
                Level = new[] { "Warn" },
                ProcessName = new[] { "ApplicationService" }

            };

            var logsData = await groupShareClient.Logs.GetFilteredLogs(filter);
            Assert.True(logsData.Count > 0);
            Assert.Equal("Warn", logsData.Items[0].Level);
            Assert.Equal("ApplicationService", logsData.Items[0].ProcessName);
        }

        [Fact]
        public async Task Logs_Paged()
        {
            var groupShareClient = Helper.GsClient;
            var logsRequest = new LogsRequest() { Page = "0", Limit = "7" };

            var logs = await groupShareClient.Logs.GetLogs(logsRequest);
            Assert.True(logs.Count > 0);
            Assert.Equal(7, logs.Items.Length);
        }

    }
}
