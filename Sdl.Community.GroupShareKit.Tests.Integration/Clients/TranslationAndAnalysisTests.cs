using Newtonsoft.Json;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationAndAnalysisTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private int _jobId;

        public TranslationAndAnalysisTests()
        {
            _jobId = CreateTestTranslateAndAnalysisJob().Result;
        }

        [Fact]
        public async Task GetJobId()
        {
            string fuzzyBands = "[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]";
            var request = new TranslationAndAnalysisJobRequest(fuzzyBands);
            var jobId = await GroupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

            Assert.True(jobId > 0);
        }

        //[Fact]
        ////[InlineData("10")]
        //public async Task GetTranslatableDocumentId()
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var fileToTranslatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FileToTranslate.txt.sdlxliff");
        //    var tmOptionsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\TMOptions.Json");
        //    var fileContent = new FileStream(fileToTranslatePath, FileMode.Open);
        //    var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
        //    var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(tmOptionsPath)).ToString();
        //    content.Add(new StreamContent(fileContent), "file", Path.GetFileName(fileToTranslatePath));
        //    content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
        //    var translationJobNo = await groupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId, content);

        //    Assert.True(translationJobNo > 0);
        //}

        [Fact]
        public async Task GetTranslationStatus()
        {
            string fuzzyBand = "[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]";

            var fileToTranslatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FileToTranslate.txt.sdlxliff");
            var tmOptionsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\TMOptions.Json");
            var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
            var jobId = await GroupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

            var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
            var fileContent = new FileStream(fileToTranslatePath, FileMode.Open);
            var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(tmOptionsPath)).ToString();
            content.Add(new StreamContent(fileContent), "file", Path.GetFileName(fileToTranslatePath));
            content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
            var translationJob = await GroupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId, content);

            var translationJobStatus = await GroupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob);

            Assert.IsType<TranslationStatus>(translationJobStatus.Status);
            Assert.IsType<bool>(translationJobStatus.IsFinal);
        }

        [Fact]
        public async Task GetAnalysisDocumentId()
        {
            var analysisJobId = await GroupShareClient.TranslateAndAnalysis.GetAnalysisJob(_jobId);

            Assert.True(analysisJobId > 0);
        }

        [Fact]
        public async Task GetAnalysisStatus()
        {
            var analysisJobStatus = await GroupShareClient.TranslateAndAnalysis.GetAnalysisStatus(_jobId);

            Assert.Equal(AnalysisStatus.NotStarted, analysisJobStatus.Status);
            Assert.False(analysisJobStatus.IsFinal);
        }

        [Fact]
        public async Task CreateAndDeleteJob()
        {
            string fuzzyBands = "[{\"minimumMatchValue\":51,\"maximumMatchValue\":70},{\"minimumMatchValue\":71,\"maximumMatchValue\":99}]";
            var request = new TranslationAndAnalysisJobRequest(fuzzyBands);

            var jobId = await GroupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);
            await GroupShareClient.TranslateAndAnalysis.DeleteJob(_jobId);
        }

        [Fact]
        public async Task TranslateAndAnalysisFlow()
        {
            // In order to run Translate and Analysis, certain steps must pe followed in a specific order. Below is and example:

            string fuzzyBand = "[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]";

            var fileToTranslatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FileToTranslate.txt.sdlxliff");
            var tmOptionsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\TMOptions.Json");
            var request = new TranslationAndAnalysisJobRequest(fuzzyBand);
            var jobId = await GroupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);

            var content = new MultipartFormDataContent($"---{Guid.NewGuid()}---");
            var fileContent = new FileStream(fileToTranslatePath, FileMode.Open);
            var optionsContent = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(tmOptionsPath)).ToString();
            content.Add(new StreamContent(fileContent), "file", Path.GetFileName(fileToTranslatePath));
            content.Add(new StringContent(optionsContent, Encoding.UTF8, "application/json"), "info");
            var translationJob = await GroupShareClient.TranslateAndAnalysis.GetTranslationJob(jobId, content);

            var translationJobStatus = await GroupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob);
            while (translationJobStatus.IsFinal != true)
            {
                translationJobStatus = await GroupShareClient.TranslateAndAnalysis.GetTranslationStatus(translationJob);
            }

            // DownloadTranslationDocument sometimes needs a small wait in order not to fail
            Thread.Sleep(2000);

            var downloadedTranslationDocument = await GroupShareClient.TranslateAndAnalysis.DownloadTranslationDocument(translationJob);
            Assert.True(downloadedTranslationDocument.GetType() == typeof(byte[]) && downloadedTranslationDocument.Length != 0);

            var analysisJob = await GroupShareClient.TranslateAndAnalysis.GetAnalysisJob(jobId);

            var analysisJobStatus = await GroupShareClient.TranslateAndAnalysis.GetAnalysisStatus(analysisJob);
            while (analysisJobStatus.IsFinal != true)
            {
                analysisJobStatus = await GroupShareClient.TranslateAndAnalysis.GetAnalysisStatus(analysisJob);
            }

            var analysisStatistics = await GroupShareClient.TranslateAndAnalysis.GetAnalysisStatistics(analysisJob);
            Assert.Equal(10, analysisStatistics.Statistics[0].Total.Segments);
            Assert.Equal(153, analysisStatistics.Statistics[0].Total.Words);

            await GroupShareClient.TranslateAndAnalysis.DeleteJob(jobId);
        }

        private async Task<int> CreateTestTranslateAndAnalysisJob()
        {
            string fuzzyBands = "[{\"minimumMatchValue\":50,\"maximumMatchValue\":84},{\"minimumMatchValue\":85,\"maximumMatchValue\":100}]";
            var request = new TranslationAndAnalysisJobRequest(fuzzyBands);

            var jobId = await GroupShareClient.TranslateAndAnalysis.GetTranslateAndAnalysisJob(request);
            return jobId;
        }

        public void Dispose()
        {
            GroupShareClient.TranslateAndAnalysis.DeleteJob(_jobId);
        }
    }
}
