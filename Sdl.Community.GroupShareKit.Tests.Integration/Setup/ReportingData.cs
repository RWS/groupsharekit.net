using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Setup
{
    public class ReportingData : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private string _projectId;
        public ReportingData()
        {
            _projectId = CreateTestProject(GroupShareClient).Result;
        }
        private async Task<bool> WaitForProjectCreated(string projectId, int retryInterval = 30, int maxTryCount = 20)
        {
            for (var i = 0; i < maxTryCount; i++)
            {
                var statusInfo = await Helper.GsClient.Project.PublishingStatus(projectId);
                switch (statusInfo.Status)
                {
                    case PublishProjectStatus.Uploading:
                    case PublishProjectStatus.Scheduled:
                    case PublishProjectStatus.Publishing:
                        break;
                    case PublishProjectStatus.Completed:
                        return true;
                    case PublishProjectStatus.Error:
                        throw new Exception(statusInfo.Description);
                }

                await Task.Delay(retryInterval * 1000);
            }

            return false;
        }

        private async Task<string> CreateTestProject(GroupShareClient groupShareClient)
        {
            var projectTemplate = groupShareClient.Project.GetAllTemplates().Result.ToList().FirstOrDefault();
            var projectTemplateId = projectTemplate != null ? projectTemplate.Id : string.Empty;

            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = $"Project - {Guid.NewGuid()}";
            var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                projectName,
                Helper.OrganizationId,
                null,
                DateTime.Now.AddDays(2),
                projectTemplateId,
                rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);
            await Task.Delay(60000);

            return projectId;
        }

        public void Dispose()
        {
            GroupShareClient.Project.DeleteProject(_projectId).Wait();
        }
    }
}
