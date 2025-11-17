using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Setup
{
    public class IntegrationTestsProjectData : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectId;
        private Guid _projectTemplateId;

        public IntegrationTestsProjectData()
        {
            _projectId = CreateTestProject().Result;
        }

        private async Task<bool> WaitForProjectCreated(string projectId, int retryInterval = 30, int maxTryCount = 20)
        {
            for (var i = 0; i < maxTryCount; i++)
            {
                var statusInfo = await Helper.GsClient.Project.GetPublishingStatus(Guid.Parse(projectId));
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

        private async Task<Guid> CreateTestProject()
        {
            var projectTemplateId = await CreateTestProjectTemplate();

            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = $"Project - {Guid.NewGuid()}";
            var projectId = await GroupShareClient.Project.CreateProject(new CreateProjectRequest(
                projectName,
                Helper.OrganizationId,
                null,
                DateTime.Now.AddDays(2),
                projectTemplateId.ToString(),
                rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);

            return Guid.Parse(projectId);
        }

        private async Task<Guid> CreateTestProjectTemplate()
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));

            var templateRequest = new ProjectTemplate
            {
                Name = $"Project template - {Guid.NewGuid()}",
                OrganizationId = Guid.Parse(Helper.OrganizationId)
            };

            var templateId = await GroupShareClient.Project.CreateProjectTemplate(templateRequest, rawData);
            
            _projectTemplateId = templateId;
            return templateId;
        }

        public void Dispose()
        {
            GroupShareClient.Project.DeleteProject(_projectId).Wait();
            GroupShareClient.Project.DeleteProjectTemplate(_projectTemplateId).Wait();
        }
    }
}
