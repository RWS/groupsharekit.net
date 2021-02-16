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

        [Fact]
        public async Task FilteredLogs()
        {
            var groupShareClient = Helper.GsClient;
            var filter = new LogsFilter
            {
                FromDate = DateTime.Now.AddDays(-15),
                ToDate = DateTime.Now,
                Level = new string[] { "Warn"},
                ProcessName = new string[] { "ApplicationService" }

            };

            var logsData = await groupShareClient.Logs.GetFilteredLogs(filter);
            Assert.True(logsData.Count > 0);
            Assert.True(logsData.Items[0].Level == "Warn");
            Assert.True(logsData.Items[0].ProcessName == "ApplicationService");
        }
    }
}
