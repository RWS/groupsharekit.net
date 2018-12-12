using Newtonsoft.Json;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationAndAnalysisTests
    {
        [Theory]
        [InlineData("[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]")]
        public async Task GetJobId(string fuzzyBand)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
            var jobId = await groupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

            Assert.True(jobId > 0);
        }

        [Theory]
        [InlineData("10", "C:\\Users\\rionescu\\Desktop\\forTM.txt.sdlxliff", "C:\\Users\\rionescu\\Desktop\\optionsJson.txt")]
        public async Task GetTranslatableDocumentId(string jobId, string filePath, string optionsJson)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
            var fileContent = new FileStream(filePath, FileMode.Open);
            var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(optionsJson)).ToString();
            content.Add(new StreamContent(fileContent), "file", Path.GetFileName(filePath));
            content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");

            var translationJob = await groupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId, content);

            Assert.True(translationJob > 0);
        }

        [Theory]
        [InlineData("9")]
        public async Task GetTranslationStatus(string translationJob)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob);
            Assert.IsType<TranslationStatus>(translationJobStatus.Status);
            Assert.IsType<bool>(translationJobStatus.IsFinal);
        }

        [Theory]
        [InlineData("9")]
        public async Task DownloadTranslationDocument(string translationJob)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var donwloadedTranslationDocument = await groupShareClient.TranslateAndAnalysis.DownloadTranslationDocument(translationJob);
        }

        [Theory]
        [InlineData("C:\\Users\\rionescu\\Desktop\\fuzzybands.txt", "C:\\Users\\rionescu\\Desktop\\forTM.txt.sdlxliff", "C:\\Users\\rionescu\\Desktop\\optionsJson.txt")]
        public async Task FullFlow(string fuzzyBand, string filePath, string optionsJson)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
            var jobId = await groupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);//got jobId
            var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
            var fileContent = new FileStream(filePath, FileMode.Open);
            var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(optionsJson)).ToString();
            content.Add(new StreamContent(fileContent), "file", Path.GetFileName(filePath));
            content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
            var translationJob = await groupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId.ToString(), content);
            var translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob.ToString());
            while (translationJobStatus.IsFinal != true)
            {
                translationJobStatus = await groupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob.ToString());
            }
            var downloadedTranslationDocument = await groupShareClient.TranslateAndAnalysis.DownloadTranslationDocument(translationJob.ToString());
        }
    }
}
