using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{

    public class ReportingClientTests
    {
        [Fact]
        public async Task PredefinedProjectsData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var projectTemplate = groupShareClient.Project.GetAllTemplates().Result.ToList().FirstOrDefault();
            var ProjectTemplateId = projectTemplate != null ? projectTemplate.Id : string.Empty;

            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = $"Project - {Guid.NewGuid()}";
            var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                 projectName,
                 Helper.OrganizationId,
                 null,
                 DateTime.Now.AddDays(2),
                 ProjectTemplateId,
                 rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);

            var reportingData = await groupShareClient.Reporting.PredefinedProjects(filters);
            Assert.True(reportingData.Count > 0);

            await Helper.GsClient.Project.DeleteProject(projectId.ToString());

        }

        [Fact]
        public async Task PredefinedTasksData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var projectTemplate = groupShareClient.Project.GetAllTemplates().Result.ToList().FirstOrDefault();
            var ProjectTemplateId = projectTemplate != null ? projectTemplate.Id : string.Empty;

            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = $"Project - {Guid.NewGuid()}";
            var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                 projectName,
                 Helper.OrganizationId,
                 null,
                 DateTime.Now.AddDays(2),
                 ProjectTemplateId,
                 rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);

            var reportingData = await groupShareClient.Reporting.PredefinedTasks(filters);
            Assert.True(reportingData.Count > 0);

            await Helper.GsClient.Project.DeleteProject(projectId.ToString());

        }

        [Fact]
        public async Task PredefinedTmLeverageData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var projectTemplate = groupShareClient.Project.GetAllTemplates().Result.ToList().FirstOrDefault();
            var ProjectTemplateId = projectTemplate != null ? projectTemplate.Id : string.Empty;

            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = $"Project - {Guid.NewGuid()}";
            var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                 projectName,
                 Helper.OrganizationId,
                 null,
                 DateTime.Now.AddDays(2),
                 ProjectTemplateId,
                 rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);

            var reportingData = await groupShareClient.Reporting.PredefinedTmLeverage(filters);
            Assert.True(reportingData.Count > 0);

            await Helper.GsClient.Project.DeleteProject(projectId.ToString());

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

    }
}
