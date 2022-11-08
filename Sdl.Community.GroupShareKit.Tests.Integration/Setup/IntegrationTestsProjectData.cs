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
        private readonly string _projectId;
        private string _projectTemplateId;

        public IntegrationTestsProjectData()
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
            var projectTemplateId = CreateProjectTemplate(groupShareClient).Result;

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

            return projectId;
        }

        private async Task<string> CreateProjectTemplate(GroupShareClient groupShareClient)
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));

            var id = Guid.NewGuid().ToString();
            var templateName = $"Project template - { Guid.NewGuid() }";
            var templateRequest = new ProjectTemplates(id, templateName, "", Helper.OrganizationId);
            var templateId = await groupShareClient.Project.CreateTemplate(templateRequest, rawData);
            
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
