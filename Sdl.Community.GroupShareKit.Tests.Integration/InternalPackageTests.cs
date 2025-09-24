using Newtonsoft.Json;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration
{
    public class InternalPackageTests
    {
        private GroupShareClient _client;
        private Guid _projectId;

        public InternalPackageTests()
        {
            var token = GroupShareClient.GetRequestToken("bruno.rothbaecher@itl.eu", "TaniaBrandt123!", new Uri("https://groupshare.dels-qa.cloud.wholesaleservices.de/"), GroupShareClient.AllScopes).Result;
            _client = GroupShareClient.AuthenticateClient(token, "bruno.rothbaecher@itl.eu", "TaniaBrandt123!", null, new Uri("https://groupshare.dels-qa.cloud.wholesaleservices.de/"), GroupShareClient.AllScopes).Result; ;

            //_projectId = Guid.Parse("fd813293-965f-4e6e-a3df-85f7b1057ed8");
            _projectId = Guid.Parse("64be09cb-222e-4aa5-87e3-b1fcad4c825b");
        }

        [Fact]
        public async Task GetProjects()
        {
            var request = new ProjectsRequest("1", "100");
            var assignment = await _client.Project.GetProject(request);
            Assert.NotNull(assignment);
        }

        [Fact]
        public async Task ExportPackageWithLanguageFileIds()
        {
            var project = await _client.Project.GetProject(_projectId);
            var files = await _client.Project.GetProjectFiles(_projectId);

            var availableFiles = files.Where(x => x.LastCheckOut == null && x.LanguageCode == project.TargetLanguage && x.IsCanceled==false).ToList();
            
            var taskId = await _client.Project.ProjectPackageExport(_projectId, availableFiles.Select(x => x.UniqueId).ToList());
            Assert.NotNull(taskId);
        }

        [Fact]
        public async Task GetPackageStatus()
        {
            var project = await _client.Project.GetProject(_projectId);
            var tasks = await GetBackgroundTasksForProject(_projectId, DateTime.Now.AddDays(-2));

            foreach (var task in tasks)
            {
                var status = await _client.Project.ProjectPackageExportStatus(task.Id);
                Console.WriteLine(status);
            }

            Assert.NotNull(tasks);
        }

        [Fact]
        public async Task DownloadExistingPackage()
        {
            var project = await _client.Project.GetProject(_projectId);
            var tasks = await GetBackgroundTasksForProject(_projectId, DateTime.Now.AddDays(-2));

            foreach(var task in tasks)
            {
                var downloadResult = await DownloadPackage(task.Id, $"c:\\temp\\{task.Reference}.sdlppx");
            }
            
            Assert.NotNull(tasks);
        }



        private async Task<List<BackgroundTask>> GetBackgroundTasksForProject(Guid projectId, DateTime? startDate)
        {
            string taskFilter = string.Empty;
            if (startDate.HasValue)
            {
                var filter = new BackgroundTasksRequestFilter()
                {
                    Type = new[] { 25 },
                    CreatedStart = startDate,
                    CreatedEnd = DateTime.Now
                };
                
                taskFilter = JsonConvert.SerializeObject(filter);
            }
            else
            {
                taskFilter = @"{""Type"":""25""}";
            }
                var tasks = await _client.Project.GetBackgroundTasks(taskFilter, 100);
            return tasks.Items.Where(x => x.ReferenceId == _projectId).ToList();
        }

        private async Task<string> DownloadPackage(Guid taskId, string filename)
        {
            var content = await _client.Project.ProjectPackageDownload(taskId);
            if (System.IO.File.Exists(filename))
            {

                System.IO.File.Delete(filename);
            }
            System.IO.File.WriteAllBytes(filename, content);

            return filename;
        }
    }

}
